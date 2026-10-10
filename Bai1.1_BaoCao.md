# BÀI THỰC HÀNH 1.1 – LÀM QUEN VỚI WINDOWS VÀ CÁC TIỆN ÍCH

## 1. Windows API
Windows API là giao diện lập trình cho phép ứng dụng gọi các chức năng do Windows cung cấp như quản lý tiến trình, tệp tin, bộ nhớ và cửa sổ. Tham khảo Microsoft Learn: https://learn.microsoft.com/en-us/windows/win32/api/

## 2. Quản lý Desktop
Màn hình Desktop được hiển thị và quản lý chủ yếu bởi Windows Explorer (`explorer.exe`), sử dụng các chức năng của hệ điều hành Windows.

## 3. File Explorer
File Explorer hỗ trợ duyệt thư mục, xem thuộc tính, sao chép, di chuyển, đổi tên và xóa tệp. Khi nhấp đúp tệp `.exe`, Windows khởi chạy chương trình; với tệp dữ liệu như `.txt` hoặc `.jpg`, Windows thường mở ứng dụng được liên kết với loại tệp đó.

## 4. Task Manager
Task Manager cho phép theo dõi ứng dụng, tiến trình, tài nguyên hệ thống và thực hiện một số thao tác quản lý tiến trình.

## 5. Các thuộc tính của process
| Thuộc tính | Ý nghĩa |
| --- | --- |
| Type | Loại tiến trình / ứng dụng |
| Status | Trạng thái tiến trình |
| Publisher | Nhà phát hành |
| PID | Mã định danh tiến trình |
| Process name | Tên tiến trình |
| Command line | Lệnh và tham số khởi chạy |
| CPU | Mức sử dụng CPU |
| Memory | Mức sử dụng RAM |
| Disk | Hoạt động đọc/ghi đĩa |
| Network | Hoạt động mạng |

## 6. Performance
Mục Performance cho phép theo dõi mức sử dụng CPU, RAM, ổ đĩa và mạng. CPU hiển thị mức tải, tốc độ, số nhân và bộ xử lý logic. Khi có nhiều ứng dụng hoạt động, tài nguyên sử dụng có thể tăng lên.

**Kết quả khảo sát trên máy cá nhân (cần tự điền khi thực hành):**

- CPU (tên, số nhân, bộ xử lý logic): ...
- CPU usage (%): ...
- Memory (tổng RAM, đang sử dụng): ...
- Disk usage: ...
- Network usage: ...
- Nhận xét tại thời điểm khảo sát: ...

## 7. Các mục khác của Task Manager
- **Users:** tài khoản đang đăng nhập, ứng dụng và tài nguyên tương ứng.
- **Details:** danh sách tiến trình và thông số chi tiết, bao gồm PID.
- **Services:** các dịch vụ của Windows.
- **Startup apps:** ứng dụng được cấu hình để khởi động cùng Windows.
- **App history:** lịch sử sử dụng tài nguyên của các ứng dụng được hỗ trợ.

## Kết luận
Bài thực hành giúp nhận biết vai trò của Windows Explorer, File Explorer, Task Manager và các thông số quản lý tiến trình, đồng thời tập cách theo dõi tài nguyên máy tính.

> Ghi chú: Thêm ảnh chụp màn hình từ máy thực hành và các chỉ số thực đo trước khi nộp nếu giảng viên yêu cầu.
