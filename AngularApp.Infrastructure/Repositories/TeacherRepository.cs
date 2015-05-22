﻿using System.Collections.Generic;
using Core.DataAccess;
using Core.Models;
using Core.Repositories;
using Dapper;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class TeacherRepository : ITeacherRepository
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public TeacherRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Insert(Teacher teacherToSave)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO [AngularApp.Sql].dbo.Teachers(Name,BirthDate,Address1,Address2,City,State,Zipcode) 
								 VALUES 
								(@Name,@BirthDate,@Address1,@Address2,@City,@State,@Zipcode); 
								SELECT CAST(SCOPE_IDENTITY() as int);";

				return connection.Query<int>(sql, teacherToSave).First();
			}
		}

		public void Update(Teacher teacherToUpdate)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"UPDATE [AngularApp.Sql].dbo.Teachers SET 
								 Name = @Name,
								 BirthDate = @BirthDate,
								 Address1 = @Address1,
								 Address2 = @Address2,
								 City = @City,
								 State = @State,
								 Zipcode = @Zipcode 
								 WHERE TeacherId = @TeacherId";

				connection.Execute(sql, teacherToUpdate);
			}
		}

		public Teacher Get(int teacherId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 TeacherId,
								 Name,
								 BirthDate,
								 Address1,
								 Address2,
								 City,
								 State,
								 Zipcode
								 FROM [AngularApp.Sql].dbo.Teachers
								 WHERE TeacherId = @teacherId";

				return connection.Query<Teacher>(sql, new { teacherId }).SingleOrDefault();
			}
		}

		public IEnumerable<Teacher> Get()
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 TeacherId,
								 Name,
								 BirthDate,
								 Address1,
								 Address2,
								 City,
								 State,
								 Zipcode
								 FROM [AngularApp.Sql].dbo.Teachers";

				return connection.Query<Teacher>(sql);
			}
		}

		public void Delete(int teacherId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.Teachers WHERE TeacherId = @teacherId";

				connection.Execute(sql, new { teacherId });
			}
		}
	}
}