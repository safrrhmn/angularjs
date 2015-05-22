﻿using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
	public interface IClassService
	{
		Class Get(int classId);
		IEnumerable<Class> Get();
		void Update(Class updateClass);
		int Insert(Class updateClass);
		void Delete(int classId);
	}
}
