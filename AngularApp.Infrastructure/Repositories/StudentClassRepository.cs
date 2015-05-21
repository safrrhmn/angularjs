using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Models;
using Core.Repositories;
using Dapper;

namespace Infrastructure.Repositories
{
	public class StudentClassRepository : IStudentClassRepository
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public StudentClassRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Insert(StudentClass studentToSave)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO [AngularApp.Sql].dbo.[Classes.Students](ClassId,StudentId) 
								 VALUES 
								(@ClassId,@StudentId); 
								SELECT CAST(SCOPE_IDENTITY() as int);";

				return connection.Query<int>(sql, studentToSave).First();
			}
		}

		public IEnumerable<StudentClass> Get(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT [Classes.StudentsId] AS StudentClassId,ClassId,StudentId FROM [AngularApp.Sql].dbo.[Classes.Students] WHERE ClassId = @classId";

				return connection.Query<StudentClass>(sql, new { classId });
			}
		}

		public void Delete(int classId, int studentId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.[Classes.Students]
								 WHERE ClassId = @classId AND StudentId = @studentId";

				connection.Execute(sql, new { classId, studentId });
			}
		}

		public void Delete(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.[Classes.Students]
								 WHERE ClassId = @classId";

				connection.Execute(sql, new { classId });
			}
		}
	}
}