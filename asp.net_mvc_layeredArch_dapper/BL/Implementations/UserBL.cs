using asp.net_mvc_layeredArch_dapper.BL.Interfaces;
using asp.net_mvc_layeredArch_dapper.DAL.Interfaces;
using asp.net_mvc_layeredArch_dapper.DAL.Model;

namespace asp.net_mvc_layeredArch_dapper.BL.Implementations
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public async Task<int?> Authenticate(string email, string password)
        {
            string encpass = Encrypt(password);
            foreach(User user in await _userDAL.FindByEmail(email))
            {
                if (user.Password == encpass)
                {
                    return user.UserId;
                }
            }
            return null;
        }

        public string Encrypt(string password)
        {
            return password;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userDAL.FindById(id);
        }
    }
}
