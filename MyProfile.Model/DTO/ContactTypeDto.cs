using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.DTO
{
	public class ContactTypeDto
	{
		public enum ContactTypeEnum
		{
			PhoneNumber = 1,
			Email = 2,
			WebSite = 3
		}

		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
