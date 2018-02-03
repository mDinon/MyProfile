using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.Entities
{
	public class ContactType : EntityBase
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Contact> Contacts { get; set; }
	}
}
