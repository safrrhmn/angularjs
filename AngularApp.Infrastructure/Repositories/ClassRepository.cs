using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Repositories;
using Core.Models;
using Dapper;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories
{
	public class ClassRepository : IClassRepository
	{
		private readonly DBConnectionFactory _dbConnectionFactory;

		public ClassRepository(DBConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Create(SlimClass insert)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DECLARE @InstanceId int
								SELECT @InstanceId = ISNULL(MAX(instanceId),0) + 1 FROM DapperTest.dbo.Classes
								INSERT INTO DapperTest.dbo.Classes(InstanceId, TeacherId, StudentId) VALUES (@InstanceId, @TeacherId, @StudentId)
								SELECT @InstanceId";
				return connection.Query<int>(sql, new { insert.TeacherId, insert.StudentId}).SingleOrDefault();
			}
		}

		public void SaveTeacher(int instanceId, int teacherId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"UPDATE DapperTest.dbo.Classes SET TeacherId = @teacherId WHERE InstanceId = @instanceId";
				connection.Execute(sql, new {instanceId, teacherId});
			}
		}

		public void SaveStudent(SlimClass insert)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO DapperTest.dbo.Classes(InstanceId, TeacherId, StudentId) VALUES (@InstanceId, @TeacherId, @StudentId)";
				connection.Execute(sql, new { insert.TeacherId, insert.StudentId });
			}
		}

		public IEnumerable<SlimClass> Get(int instanceId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT
								 InstanceId
								 TeacherId
								 StudentId
								 FROM DapperTest.dbo.Classes
								 WHERE InstanceId = @instanceId";
				return connection.Query<SlimClass>(sql, instanceId);
			}
		}

		public void Delete(int instanceId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM DapperTest.dbo.Classes WHERE InstanceId = @instanceId";
				connection.Execute(sql, instanceId);
			}
		}

		public void DeleteStudent(int instanceId, int studentId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM DapperTest.dbo.Classes WHERE InstanceId = @instanceId AND StudentId = @studentId";
				connection.Execute(sql, new { instanceId, studentId });
			}
		}
	}
}
