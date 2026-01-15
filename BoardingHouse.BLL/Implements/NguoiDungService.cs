using System;
using System.Threading.Tasks;
using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Implements;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.BLL.Implements
{
    public class NguoiDungService : INguoiDungService
    {
        private readonly INguoiDungRepository _repo;

        public NguoiDungService()
        {
            var context = new BoardingHouseContext();
            _repo = new NguoiDungRepository(context);
        }

        public async Task<NguoiDung> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Tài khoản và mật khẩu không được để trống!");

            var user = await _repo.GetByUsernameAsync(username);

            if (user == null)
                throw new Exception("Tài khoản không tồn tại!");

            // Trong thực tế nên dùng BCrypt để so sánh hash
            if (user.Password != password)
                throw new Exception("Mật khẩu không chính xác!");

            return user;
        }

        public async Task ChangePasswordAsync(string username, string oldPass, string newPass)
        {
            var user = await LoginAsync(username, oldPass);

            if (string.IsNullOrWhiteSpace(newPass))
                throw new ArgumentException("Mật khẩu mới không hợp lệ!");

            user.Password = newPass;
            await _repo.UpdateAsync(user);
            await _repo.SaveChangesAsync();
        }
    }
}