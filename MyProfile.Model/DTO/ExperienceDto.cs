using System;
using System.ComponentModel.DataAnnotations;
using MyProfile.Model.Entities;

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
		public OwnerDto Owner { get; set; }
		public ExperienceTypeDto ContactType { get; set; }
	}
}
