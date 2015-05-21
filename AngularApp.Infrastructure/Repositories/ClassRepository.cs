using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Models;
using Core.Repositories;
using Dapper;

namespace Infrastructure.Repositories
{
	public class ClassRepository : IClassRepository
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public ClassRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public SlimClass Get(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 ClassId
								 Name
								 Description
								 FROM [AngularApp.Sql].dbo.Classes
								 WHERE ClassId = @classId";
				return connection.Query<SlimClass>(sql, classId).SingleOrDefault();
			}
		}

		public int Insert(SlimClass updateClass)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO [AngularApp.Sql].dbo.Classes(Name,Description) 
								 VALUES 
								(@Name,@Description); 
								SELECT CAST(SCOPE_IDENTITY() as int);";

				return connection.Query<int>(sql, updateClass).First();
			}
		}

		public void Delete(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.Classes WHERE ClassId = @classId";
				connection.Execute(sql, classId);
			}
		}		

		public IEnumerable<SlimClass> Get()
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 ClassId
								 Name
								 Description
								 FROM [AngularApp.Sql].dbo.Classes";
				return connection.Query<SlimClass>(sql);
			}
		}

		public void Update(SlimClass updateClass)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"update [AngularApp.Sql].dbo.Classes set Name = @Name,Description = @Description where ClassId = @ClassId";
				connection.Execute(sql, updateClass);
			}
		}
	}
}
