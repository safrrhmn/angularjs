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

		public Class Get(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 C.ClassId,
								 C.Name,
								 C.Description,
								 T.TeacherId,
								 T.Name,
								 T.BirthDate,
								 T.Address1,
								 T.Address2,
								 T.City,
								 T.State,
								 T.Zipcode
								 FROM [AngularApp.Sql].dbo.Classes C
								 left outer join [AngularApp.Sql].dbo.[Classes.Teachers] CT on CT.ClassId = C.ClassId
								 Left outer join [AngularApp.Sql].dbo.[Teachers] T on T.TeacherId = CT.TeacherId
								 WHERE C.ClassId = @classId";
				return connection.Query<Class, Teacher, Class>(sql, (@class, teacher) =>
				{
					@class.Teacher = teacher;
					return @class;
				}, new { classId }, splitOn: "TeacherId").SingleOrDefault();
			}
		}

		public int Insert(Class updateClass)
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
				connection.Execute(sql, new { classId });
			}
		}

		public IEnumerable<Class> Get()
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 C.ClassId,
								 C.Name,
								 C.Description,
								 T.TeacherId,
								 T.Name,
								 T.BirthDate,
								 T.Address1,
								 T.Address2,
								 T.City,
								 T.State,
								 T.Zipcode
								 FROM [AngularApp.Sql].dbo.Classes C
								 left outer join [AngularApp.Sql].dbo.[Classes.Teachers] CT on CT.ClassId = C.ClassId
								 Left outer join [AngularApp.Sql].dbo.[Teachers] T on T.TeacherId = CT.TeacherId";
				return connection.Query<Class, Teacher, Class>(sql, (@class, teacher) =>
				{
					@class.Teacher = teacher;
					return @class;
				}, splitOn: "TeacherId");
			}
		}

		public void Update(Class updateClass)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"update [AngularApp.Sql].dbo.Classes set Name = @Name,Description = @Description where ClassId = @ClassId";
				connection.Execute(sql, updateClass);
			}
		}
	}
}
