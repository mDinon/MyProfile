using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.Model.Entities
{
	public class Contact : EntityBase
	{
		[Required]
		[ForeignKey("Owner")]
		public int Owner_ID { get; set; }
		[Required]
		[ForeignKey("ContactType")]
		public int ContactType_ID { get; set; }
		public string ContactInfo { get; set; }

		public virtual Owner Owner { get; set; }
		public virtual ContactType ContactType { get; set; }
	}
}
