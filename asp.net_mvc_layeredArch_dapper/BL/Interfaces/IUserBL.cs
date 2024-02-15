using asp.net_mvc_layeredArch_dapper.DAL.Model;

namespace asp.net_mvc_layeredArch_dapper.BL.Interfaces
{
    public interface IUserBL
    {
        Task<int?> Authenticate(string email, string password);
        Task<User> GetUserById(int id);
    }
}
