using Core.Models;

namespace Core.Services
{
	public interface ITeacherClassService
	{
		int Insert(TeacherClass teacherToSave);
		TeacherClass Get(int classId);
		void Delete(int classId, int teacherId);
		void Delete(int teacherClassId);
	}
}