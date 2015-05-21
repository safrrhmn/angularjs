using System.Collections.Generic;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Infrastructure.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly ITeacherRepository _repository;

		public TeacherService(ITeacherRepository repository)
		{
			_repository = repository;
		}

		public int Insert(Teacher teacherToSave)
		{
			return _repository.Insert(teacherToSave);
		}

		public void Update(Teacher teacherToUpdate)
		{
			_repository.Update(teacherToUpdate);
		}

		public Teacher Get(int teacherId)
		{
			return _repository.Get(teacherId);
		}

		public IEnumerable<Teacher> Get()
		{
			return _repository.Get();
		}

		public void Delete(int teacherId)
		{
			_repository.Delete(teacherId);
		}
	}
}