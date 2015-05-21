using Core.Models;

namespace Core.Interfaces.Repositories
{
	public interface ITeacherRepository
	{
		int Save(Teacher teacherToSave);
		void Update(Teacher teacherToUpdate);
		Teacher Get(int teacherId);
		void Delete(int teacherId);
	}
}