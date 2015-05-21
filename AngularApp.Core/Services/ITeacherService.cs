using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
	public interface ITeacherService
	{
		int Insert(Teacher teacherToSave);
		void Update(Teacher teacherToUpdate);
		Teacher Get(int teacherId);
		IEnumerable<Teacher> Get();
		void Delete(int teacherId);
	}
}