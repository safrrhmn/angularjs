using System.Collections.Generic;
using Core.Models;

namespace Core.Repositories
{
	public interface IClassRepository
	{
		Class Get(int classId);
		IEnumerable<Class> Get();
		void Update(Class updateClass);
		int Insert(Class updateClass);
		void Delete(int classId);
	}
}
