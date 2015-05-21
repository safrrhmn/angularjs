using System.Linq;
using Core.Interfaces.Repositories;
using Core.Models;
using Dapper;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly DBConnectionFactory _dbConnectionFactory;

		public StudentRepository(DBConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Save(Student studentToSave)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO DapperTest.dbo.Students(Name,BirthDate,Address1,Address2,City,State,Zipcode) 
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
				const string sql = @"UPDATE DapperTest.dbo.Students SET 
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
								 FROM DapperTest.dbo.Students
								 WHERE StudentId = @studentId";

				return connection.Query<Student>(sql, studentId).SingleOrDefault();
			}
		}

		public void Delete(int studentId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM DapperTest.dbo.Students WHERE StudentId = @studentId";

				connection.Execute(sql, studentId);
			}
		}
	}
}