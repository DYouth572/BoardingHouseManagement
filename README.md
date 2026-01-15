# Boarding House Management (Phần mềm Quản lý Nhà trọ)

Hệ thống quản lý nhà trọ chuyên nghiệp được phát triển bằng **C# WinForms** và **Entity Framework Core**, tuân thủ kiến trúc **3-Layer**.

## Tính năng nổi bật

* **Quản lý Phòng trọ:** Theo dõi trạng thái (Trống/Đã thuê), đơn giá.
* **Ghi điện nước:** Tự động lấy chỉ số cũ, tính toán tiền theo bậc thang hoặc giá cố định.
* **Xử lý Hóa đơn:**
    * Tính tổng tiền tự động (Điện + Nước + Dịch vụ + Mạng).
    * **Transaction:** Đảm bảo tính toàn vẹn dữ liệu khi lưu hóa đơn.
    * Ngăn chặn trùng lặp hóa đơn trong cùng một tháng.
* **Báo cáo & In ấn:**
    * Xuất phiếu thu ra Excel chuyên nghiệp (sử dụng COM Interop).

## 🛠 Công nghệ sử dụng

* **Ngôn ngữ:** C# (.NET Framework / .NET Core)
* **Giao diện:** Windows Forms (WinForms)
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code First)
* **Architecture:** 3-Layer Pattern (Entities - DAL - BLL - UI)
* **Design Pattern:** Repository Pattern, Singleton, Dependency Injection (Basic).

## Cài đặt & Chạy dự án

1.  Clone dự án về máy:
    ```bash
    git clone [https://github.com/DYouth572/BoardingHouseManagement.git](https://github.com/DYouth572/BoardingHouseManagement.git)
    ```
2.  Mở file `app.config` , chỉnh sửa **ConnectionString** phù hợp với SQL Server của bạn.
3.  Mở **Package Manager Console** trong Visual Studio và chạy lệnh để sinh Database:
    ```powershell
    Update-Database
    ```
4.  Chạy dự án (F5).
**Author:** DYouth572
