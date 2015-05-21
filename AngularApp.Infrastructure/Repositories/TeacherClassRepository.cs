using System.Linq;
using Core.DataAccess;
using Core.Models;
using Core.Repositories;
using Dapper;

namespace Infrastructure.Repositories
{
	public class TeacherClassRepository : ITeacherClassRepository
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public TeacherClassRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public int Insert(TeacherClass teacherToSave)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"INSERT INTO [AngularApp.Sql].dbo.[Classes.Teachers](ClassId,TeacherId) 
								 VALUES 
								(@ClassId,@TeacherId); 
								SELECT CAST(SCOPE_IDENTITY() as int);";

				return connection.Query<int>(sql, teacherToSave).First();
			}
		}

		public TeacherClass Get(int classId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"SELECT Classes.StudentsId AS TeacherClassId,ClassId,TeacherId FROM [AngularApp.Sql].dbo.[Classes.Teachers] WHERE ClassId = @classId";

				return connection.Query<TeacherClass>(sql, classId).SingleOrDefault();
			}
		}

		public void Delete(int classId, int teacherId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.[Classes.Teachers]
								 WHERE ClassId = @classId AND TeacherId = @teacherId";

				connection.Execute(sql, new { classId, teacherId });
			}
		}

		public void Delete(int teacherClassId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string sql = @"DELETE FROM [AngularApp.Sql].dbo.[Classes.Teachers]
								 WHERE Classes.TeachersId = @eacherClassId";

				connection.Execute(sql, teacherClassId);
			}
		}
	}
}