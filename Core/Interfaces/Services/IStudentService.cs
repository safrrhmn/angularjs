using Core.Models;

namespace Core.Interfaces.Services
{
	public interface IStudentService
	{
		int Save(Student studentToSave);
		void Update(Student studentToUpdate);
		Student Get(int studentId);
		void Delete(int studentId);
	}
}