using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.DTO
{
	public class ExperienceTypeDto
	{
		public enum ExperienceTypeEnum
		{
			Education = 1,
			Work = 2,
		}

		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
