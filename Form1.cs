using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessManager;

public class Form1 : Form
{
    private readonly TextBox txtPath = new();
    private readonly ListBox lbOutput = new();
    private readonly Button btnBrowse = new();
    private readonly Button btnStart = new();
    private readonly Button btnRefresh = new();
    private readonly Button btnStop = new();

    public Form1()
    {
        Text = "Quản lý process";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(740, 460);
        MinimumSize = new Size(590, 350);

        btnBrowse.Text = "Browse...";
        btnBrowse.Name = "btnBrowse";
        btnBrowse.SetBounds(15, 15, 95, 30);

        txtPath.Name = "txtPath";
        txtPath.SetBounds(120, 18, 490, 26);
        txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        btnStart.Text = "Start";
        btnStart.Name = "btnStart";
        btnStart.SetBounds(625, 15, 100, 30);
        btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        var title = new Label
        {
            Text = "Các process đã được kích hoạt và đang chạy:",
            AutoSize = true,
            Location = new Point(15, 60)
        };

        lbOutput.Name = "lbOutput";
        lbOutput.SetBounds(15, 85, 710, 310);
        lbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lbOutput.HorizontalScrollbar = true;

        btnRefresh.Text = "Refresh";
        btnRefresh.Name = "btnRefresh";
        btnRefresh.SetBounds(15, 410, 100, 30);
        btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        btnStop.Text = "Stop";
        btnStop.Name = "btnStop";
        btnStop.SetBounds(625, 410, 100, 30);
        btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        Controls.AddRange(new Control[] { btnBrowse, txtPath, btnStart, title, lbOutput, btnRefresh, btnStop });

        btnBrowse.Click += btnBrowse_Click;
        btnStart.Click += btnStart_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnStop.Click += btnStop_Click;
        DisplayProcess();
    }

    private void btnBrowse_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Chọn chương trình cần chạy",
            Filter = "Chương trình (*.exe)|*.exe|Tất cả tệp (*.*)|*.*",
            CheckFileExists = true
        };
        if (dlg.ShowDialog(this) == DialogResult.OK)
            txtPath.Text = dlg.FileName;
    }

    private void btnStart_Click(object? sender, EventArgs e)
    {
        var filePath = txtPath.Text.Trim();
        if (!File.Exists(filePath))
        {
            MessageBox.Show(this, "Vui lòng chọn đường dẫn tệp .exe hợp lệ.");
            return;
        }
        try
        {
            using var process = new Process();
            process.StartInfo.FileName = filePath;
            process.StartInfo.UseShellExecute = true;
            process.Start();
            DisplayProcess();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Không thể khởi chạy");
        }
    }

    private void btnRefresh_Click(object? sender, EventArgs e) => DisplayProcess();

    private void btnStop_Click(object? sender, EventArgs e)
    {
        if (lbOutput.SelectedItem is not ProcessItem selected)
        {
            MessageBox.Show(this, "Vui lòng chọn một process trong danh sách.");
            return;
        }
        if (selected.Id == Environment.ProcessId)
        {
            MessageBox.Show(this, "Không thể tự dừng chương trình đang sử dụng.");
            return;
        }
        var confirm = MessageBox.Show(this,
            $"Bạn có chắc muốn dừng {selected.Name} (PID: {selected.Id})?\nDữ liệu chưa lưu của chương trình có thể bị mất.",
            "Xác nhận dừng process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var proc = Process.GetProcessById(selected.Id);
            proc.Kill();
            proc.WaitForExit(2000);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Không thể dừng process");
        }
        finally
        {
            DisplayProcess();
        }
    }

    private void DisplayProcess()
    {
        lbOutput.BeginUpdate();
        try
        {
            lbOutput.Items.Clear();
            foreach (var process in Process.GetProcesses().OrderBy(p => p.ProcessName))
            {
                try { lbOutput.Items.Add(new ProcessItem(process.ProcessName, process.Id)); }
                catch (Exception) { /* Process có thể kết thúc trong lúc cập nhật. */ }
                finally { process.Dispose(); }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi đọc danh sách process");
        }
        finally { lbOutput.EndUpdate(); }
    }

    private sealed record ProcessItem(string Name, int Id)
    {
        public override string ToString() => $"{Name}, {Id}";
    }
}
