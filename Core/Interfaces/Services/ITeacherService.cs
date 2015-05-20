using Core.Models;

namespace Core.Interfaces.Services
{
	public interface ITeacherService
	{
		int Save(Teacher teacherToSave);
		void Update(Teacher teacherToUpdate);
		Teacher Get(int teacherId);
		void Delete(int teacherId);
	}
}