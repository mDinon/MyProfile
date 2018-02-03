using System.ComponentModel.DataAnnotations;
using MyProfile.Model.Entities;

namespace MyProfile.Model.DTO
{
	public class AddressDto
	{
		public int ID { get; set; }

		[Required]
		public string Street { get; set; }
		[Required]
		public string Town { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string PostalCode { get; set; }
	}
}
