using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Infrastructure.Services
{
	public class TeacherClassService : ITeacherClassService
	{
		private readonly ITeacherClassRepository _teacherClassRepository;

		public TeacherClassService(ITeacherClassRepository teacherClassRepository)
		{
			_teacherClassRepository = teacherClassRepository;
		}

		public int Insert(TeacherClass teacherToSave)
		{
			return _teacherClassRepository.Insert(teacherToSave);
		}

		public TeacherClass Get(int classId)
		{
			return _teacherClassRepository.Get(classId);
		}

		public void Delete(int classId, int teacherId)
		{
			_teacherClassRepository.Delete(classId,teacherId);
		}

		public void Delete(int teacherClassId)
		{
			_teacherClassRepository.Delete(teacherClassId);			
		}
	}
}