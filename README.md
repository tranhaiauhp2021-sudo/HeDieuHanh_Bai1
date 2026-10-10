# Thực hành Hệ điều hành – Bài 1.1 và 1.2

## Bài 1.1 – Làm quen với Windows

Xem [Bai1.1_BaoCao.md](Bai1.1_BaoCao.md). Phần khảo sát hiệu suất cần bổ sung số liệu và ảnh chụp từ máy thực hành.

## Bài 1.2 – Quản lý Process bằng C# Windows Forms

Mã nguồn ở thư mục [`Bai1.2_ProcessManager/`](Bai1.2_ProcessManager/).

Chức năng:
- **Browse**: chọn file `.exe`.
- **Start**: khởi chạy chương trình đã chọn.
- **Refresh**: cập nhật danh sách process (tên, PID).
- **Stop**: kết thúc process đã chọn sau khi xác nhận.

### Chạy chương trình

Yêu cầu: **Windows**, **Visual Studio 2022** có workload **.NET desktop development**, **.NET 8 SDK**.

1. Chọn **Open a project or solution** trong Visual Studio.
2. Mở `Bai1.2_ProcessManager/ProcessManager.csproj`.
3. Nhấn **F5** để chạy.
4. Thử chọn `C:\Windows\System32\notepad.exe`, bấm **Start**, **Refresh**, chọn process tương ứng rồi bấm **Stop**.

> Lưu ý: Dừng process có thể làm mất dữ liệu chưa lưu. Không dừng các process hệ thống.

### API sử dụng

`System.Diagnostics.Process`, `Process.Start()`, `Process.GetProcesses()`, `Process.GetProcessById()`, `Process.Kill()`.

Đây là mã nguồn học tập; kết quả chạy và thông số hệ thống cần kiểm tra trên máy Windows thực tế.
