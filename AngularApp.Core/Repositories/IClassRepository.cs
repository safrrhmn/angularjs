using System.Collections.Generic;
using Core.Models;

namespace Core.Repositories
{
	public interface IClassRepository
	{
		SlimClass Get(int classId);
		IEnumerable<SlimClass> Get();
		void Update(SlimClass updateClass);
		int Insert(SlimClass updateClass);
		void Delete(int classId);
	}
}
