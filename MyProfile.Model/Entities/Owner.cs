using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.Entities
{
	public class Owner : EntityBase
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime? DateBirth { get; set; }

		public virtual ICollection<Experience> Experience { get; set; }
		public virtual ICollection<Contact> Contact { get; set; }
		public virtual ICollection<Address> Address { get; set; }
	}
}
