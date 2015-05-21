using Core.Models;

namespace Core.Repositories
{
	public interface IStudentRepository
	{
		int Save(Student studentToSave);
		void Update(Student studentToUpdate);
		Student Get(int studentId);
		void Delete(int studentId);
	}
}