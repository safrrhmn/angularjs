using System;

namespace Core.Models
{
	public class Teacher
	{
		public int TeacherId { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int Zipcode { get; set; }
	}
}