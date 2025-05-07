using System.Data;

namespace Application.Shared.Repositories.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
