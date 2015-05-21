using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Infrastructure.Services
{
	public class ClassService : IClassService
	{
		private readonly IClassRepository _classRepository;
		private readonly IStudentService _studentService;
		private readonly ITeacherService _teacherService;

		public ClassService(IClassRepository classRepository, IStudentService studentService, ITeacherService teacherService)
		{
			_classRepository = classRepository;
			_studentService = studentService;
			_teacherService = teacherService;
		}

		public int Create(SlimClass insert)
		{
			return _classRepository.Create(insert);
		}

		public void SaveTeacher(int instanceId, int teacherId)
		{
			_classRepository.SaveTeacher(instanceId, teacherId);
		}

		public void SaveStudent(SlimClass insert)
		{
			_classRepository.SaveStudent(insert);
		}

		public Class Get(int instanceId)
		{
			var slims = _classRepository.Get(instanceId).ToList();
			var teacher = _teacherService.Get(slims.First().TeacherId);
			var students = slims.Select(item => _studentService.Get(item.StudentId));
			return new Class
			{
				InstanceId = instanceId,
				Teacher = teacher,
				Students = students
			};
		}

		public IEnumerable<Class> Get()
		{
			throw new System.NotImplementedException();
		}

		public void Delete(int instanceId)
		{
			_classRepository.Delete(instanceId);
		}

		public void DeleteStudent(int instanceId, int studentId)
		{
			_classRepository.DeleteStudent(instanceId, studentId);
		}
	}
}
