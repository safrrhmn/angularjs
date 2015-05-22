using System.Collections.Generic;

namespace Core.Models
{
	public class Class
	{	
		public int ClassId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Teacher Teacher { get; set; }
		public IEnumerable<Student> Students { get; set; }
	}
}