using System.Data;

namespace Questao5.Infrastructure.Interfaces
{    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }

}
