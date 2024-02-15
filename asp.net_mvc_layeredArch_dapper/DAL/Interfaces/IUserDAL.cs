using asp.net_mvc_layeredArch_dapper.DAL.Model;

namespace asp.net_mvc_layeredArch_dapper.DAL.Interfaces
{
    public interface IUserDAL
    {
        Task<IEnumerable<User>> FindByEmail(string email);
        Task<User> FindById(int id);
    }
}
