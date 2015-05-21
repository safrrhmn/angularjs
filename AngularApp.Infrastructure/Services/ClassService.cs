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
		private readonly IStudentClassService _studentClassService;
		private readonly ITeacherClassService _teacherClassService;

		public ClassService(IClassRepository classRepository, IStudentService studentService, ITeacherService teacherService, IStudentClassService studentClassService, ITeacherClassService teacherClassService)
		{
			_classRepository = classRepository;
			_studentService = studentService;
			_teacherService = teacherService;
			_studentClassService = studentClassService;
			_teacherClassService = teacherClassService;
		}


		public Class Get(int classId)
		{
			var slimclass = _classRepository.Get(classId);
			var teacher = _teacherClassService.Get(classId);
			var students = _studentClassService.Get(classId);
			return new Class
			{
				ClassId = slimclass.ClassId,
				Description = slimclass.Description,
				Name = slimclass.Name,
				Students = students.Select(item => _studentService.Get(item.StudentId)),
				Teacher = _teacherService.Get(teacher.TeacherId)
			};
		}

		public IEnumerable<Class> Get()
		{
			var slimclass = _classRepository.Get();

			return slimclass.Select(item =>
			{
				var teacher = _teacherClassService.Get(item.ClassId);
				var students = _studentClassService.Get(item.ClassId);
				return new Class
				{
					ClassId = item.ClassId,
					Description = item.Description,
					Name = item.Name,
					Students = students.Select(student => _studentService.Get(student.StudentId)),
					Teacher = _teacherService.Get(teacher.TeacherId)
				};
			});
		}

		public void Update(SlimClass updateClass)
		{
			_classRepository.Update(updateClass);
		}

		public int Insert(SlimClass updateClass)
		{
			return _classRepository.Insert(updateClass);
		}

		public void Delete(int classId)
		{
			_classRepository.Delete(classId);
		}
	}
}
