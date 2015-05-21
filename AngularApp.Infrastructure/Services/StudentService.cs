using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Infrastructure.Services
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _repository;

		public StudentService(IStudentRepository repository)
		{
			_repository = repository;
		}

		public int Save(Student studentToSave)
		{
			return _repository.Save(studentToSave);
		}

		public void Update(Student studentToUpdate)
		{
			_repository.Update(studentToUpdate);			
		}

		public Student Get(int studentId)
		{
			return _repository.Get(studentId);
		}

		public void Delete(int studentId)
		{
			_repository.Delete(studentId);
		}
	}
}