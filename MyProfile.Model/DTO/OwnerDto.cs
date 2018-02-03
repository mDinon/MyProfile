using System;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.DTO
{
	public class OwnerDto
	{
		public int ID { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime? DateBirth { get; set; }
	}
}
