using System.Collections.Generic;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Infrastructure.Services
{
	public class StudentClassService : IStudentClassService
	{
		private readonly IStudentClassRepository _studentClassRepository;

		public StudentClassService(IStudentClassRepository studentClassRepository)
		{
			_studentClassRepository = studentClassRepository;
		}

		public int Insert(StudentClass studentToSave)
		{
			return _studentClassRepository.Insert(studentToSave);
		}

		public IEnumerable<StudentClass> Get(int classId)
		{
			return _studentClassRepository.Get(classId);
		}

		public void Delete(int classId, int studentId)
		{
			_studentClassRepository.Delete(classId, studentId);
		}

		public void Delete(int studentClassId)
		{
			_studentClassRepository.Delete(studentClassId);
		}
	}
}