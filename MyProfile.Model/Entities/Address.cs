using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.Model.Entities
{
	public class Address : EntityBase
	{
		[Required]
		[ForeignKey("Owner")]
		public int Owner_ID { get; set; }
		[Required]
		public string Street { get; set; }
		[Required]
		public string Town { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string PostalCode { get; set; }

		public virtual Owner Owner { get; set; }
	}
}
