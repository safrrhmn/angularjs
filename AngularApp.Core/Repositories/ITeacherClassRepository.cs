using Core.Models;

namespace Core.Repositories
{
	public interface ITeacherClassRepository
	{
		int Insert(TeacherClass teacherToSave);
		TeacherClass Get(int classId);
		void Delete(int classId, int teacherId);
		void Delete(int classId);
	}
}