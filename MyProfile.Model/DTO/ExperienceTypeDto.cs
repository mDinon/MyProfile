﻿using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.DTO
{
	public class ExperienceTypeDto
	{
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
