using Core.Models;

namespace Core.Interfaces.Services
{
	public interface IClassService
	{
		int Create(SlimClass insert);
		void SaveTeacher(int instanceId, int teacherId);
		void SaveStudent(SlimClass insert);
		Class Get(int instanceId);
		void Delete(int instanceId);		
		void DeleteStudent(int instanceId, int studentId);
	}
}
