using System.ComponentModel.DataAnnotations;
using MyProfile.Model.Entities;

namespace MyProfile.Model.DTO
{
	public class ContactDto
	{
		public int ID { get; set; }
		[Required]
		public string ContactInfo { get; set; }
		[Required]
		public int ContactType_ID { get; set; }
	}
}
