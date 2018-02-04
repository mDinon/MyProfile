using System;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.DTO
{
	public class ExperienceDto
	{
		public int ID { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public DateTime? DateBegin { get; set; }
		public DateTime? DateEnd { get; set; }
		[Required]
		public int ExperienceType_ID { get; set; }
	}
}
