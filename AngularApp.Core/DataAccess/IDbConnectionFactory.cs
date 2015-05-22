using System.Data;

namespace Core.DataAccess
{
	public interface IDbConnectionFactory
	{
		IDbConnection GetConnection();
	}
}
