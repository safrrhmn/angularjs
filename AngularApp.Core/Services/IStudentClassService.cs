using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
	public interface IStudentClassService
	{
		int Insert(StudentClass studentToSave);		
		IEnumerable<StudentClass> Get(int classId);
		void Delete(int classId, int studentId);
		void Delete(int classId);
	}
}