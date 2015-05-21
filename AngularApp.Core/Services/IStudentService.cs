using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
	public interface IStudentService
	{
		int Insert(Student studentToSave);
		void Update(Student studentToUpdate);
		Student Get(int studentId);
		IEnumerable<Student> Get();
		void Delete(int studentId);
	}
}