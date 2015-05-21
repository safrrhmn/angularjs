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
			slimclass.Students = _studentClassService.Get(classId).Select(item => _studentService.Get(item.StudentId));
			return slimclass;
		}

		public IEnumerable<Class> Get()
		{
			var slimclass = _classRepository.Get();

			return slimclass.Select(item =>
			{				
				var students = _studentClassService.Get(item.ClassId).Select(student => _studentService.Get(student.StudentId));
				item.Students = students;
				return item;				
			});
		}

		public void Update(Class updateClass)
		{
			_classRepository.Update(updateClass);
		}

		public int Insert(Class updateClass)
		{
			return _classRepository.Insert(updateClass);
		}

		public void Delete(int classId)
		{
			_studentClassService.Delete(classId);
			_teacherClassService.Delete(classId);
			_classRepository.Delete(classId);
		}
	}
}
