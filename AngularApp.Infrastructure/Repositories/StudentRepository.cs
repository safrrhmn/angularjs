using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Models;
using Core.Repositories;
using Dapper;

namespace Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public StudentRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Insert(Student studentToSave)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO [AngularApp.Sql].dbo.Students(Name,BirthDate,Address1,Address2,City,State,Zipcode) 
								 VALUES 
								(@Name,@BirthDate,@Address1,@Address2,@City,@State,@Zipcode); 
								SELECT CAST(SCOPE_IDENTITY() as int);";

				return connection.Query<int>(sql, studentToSave).First();
			}
		}

		public void Update(Student studentToUpdate)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"UPDATE [AngularApp.Sql].dbo.Students SET 
								 Name = @Name,
								 BirthDate = @BirthDate,
								 Address1 = @Address1,
								 Address2 = @Address2,
								 City = @City,
								 State = @State,
								 Zipcode = @Zipcode 
								 WHERE StudentId = @StudentId";

				connection.Execute(sql, studentToUpdate);
			}
		}

		public Student Get(int studentId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 StudentId,
								 Name,
								 BirthDate,
								 Address1,
								 Address2,
								 City,
								 State,
								 Zipcode
								 FROM [AngularApp.Sql].dbo.Students
								 WHERE StudentId = @studentId";

				return connection.Query<Student>(sql, new {studentId}).SingleOrDefault();
			}
		}

		public IEnumerable<Student> Get()
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 StudentId,
								 Name,
								 BirthDate,
								 Address1,
								 Address2,
								 City,
								 State,
								 Zipcode
								 FROM [AngularApp.Sql].dbo.Students";

				return connection.Query<Student>(sql);
			}
		}

		public void Delete(int studentId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.Students WHERE StudentId = @studentId";

				connection.Execute(sql, studentId);
			}
		}
	}
}