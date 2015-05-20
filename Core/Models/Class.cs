using System.Collections.Generic;

namespace Core.Models
{
	public class Class
	{	
		public int InstanceId { get; set; }
		public Teacher Teacher { get; set; }
		public IEnumerable<Student> Students { get; set; }
	}
}