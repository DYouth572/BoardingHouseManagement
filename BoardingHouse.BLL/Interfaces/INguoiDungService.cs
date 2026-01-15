using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface INguoiDungService
    {
        // Hàm đăng nhập: Trả về User nếu đúng, ném Exception nếu sai
        Task<NguoiDung> LoginAsync(string username, string password);

        // Đổi mật khẩu: Cần check mật khẩu cũ có đúng không mới cho đổi
        Task ChangePasswordAsync(string username, string oldPass, string newPass);
    }
}