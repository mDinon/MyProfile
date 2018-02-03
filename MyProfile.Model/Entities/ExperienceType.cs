using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Model.Entities
{
	public class ExperienceType : EntityBase
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Experience> Experiences { get; set; }
	}
}
