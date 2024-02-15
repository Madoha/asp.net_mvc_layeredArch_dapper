using asp.net_mvc_layeredArch_dapper.DAL.Interfaces;
using asp.net_mvc_layeredArch_dapper.DAL.Model;
using Dapper;

namespace asp.net_mvc_layeredArch_dapper.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public async Task<IEnumerable<User>> FindByEmail(string email)
        {
            using (var connection = DbConnection.CreateConnection()){
                return await connection.QueryAsync<User>("SELECT * FROM [User] where Email = @Email", new { Email = email });
            }
        }

        public async Task<User?> FindById(int id)
        {
            using (var connection = DbConnection.CreateConnection()) 
            {
                return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM [User] WHERE UserId = @Id", new { Id = id });
            }
        }
    }
}
 