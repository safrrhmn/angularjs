using System.Collections.Generic;
using Core.Models;

namespace Core.Repositories
{
	public interface IStudentClassRepository
	{
		int Insert(StudentClass studentToSave);		
		IEnumerable<StudentClass> Get(int classId);
		void Delete(int classId, int studentId);
		void Delete(int studentClassId);
	}
}