using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess;

namespace Infrastructure.DataAccess
{
	public class DbConnectionFactory : IDbConnectionFactory
	{
		private readonly List<SqlConnection> _connectionList;
		private readonly string _connectionstring;

		public DbConnectionFactory(string connectionstring)
		{
			_connectionstring = connectionstring;
			_connectionList = new List<SqlConnection>();
		}

		public IDbConnection GetConnection()
		{
			var connection = new SqlConnection(_connectionstring);
			connection.Open();
			_connectionList.Add(connection);
			return connection;
		}

		public void Dispose()
		{
			var conlist = _connectionList.Where(con => !con.Equals(null)).ToList();
			foreach (var sqlConnection in conlist)
			{
				_connectionList.Remove(sqlConnection);
				sqlConnection.Dispose();
			}
		}
	}
}