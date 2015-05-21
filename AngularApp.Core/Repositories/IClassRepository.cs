using System.Collections.Generic;
using Core.Models;

namespace Core.Repositories
{
	public interface IClassRepository
	{
		int Create(SlimClass insert);
		void SaveTeacher(int instanceId, int teacherId);
		void SaveStudent(SlimClass insert);
		IEnumerable<SlimClass> Get(int instanceId);
		void Delete(int instanceId);
		void DeleteStudent(int instanceId, int studentId);
	}
}
