using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
	public interface IClassService
	{
		int Create(SlimClass insert);
		void SaveTeacher(int instanceId, int teacherId);
		void SaveStudent(SlimClass insert);
		Class Get(int instanceId);
		IEnumerable<Class> Get(); 
		void Delete(int instanceId);		
		void DeleteStudent(int instanceId, int studentId);
	}
}
