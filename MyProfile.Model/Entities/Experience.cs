using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.Model.Entities
{
	public class Experience : EntityBase
	{
		[Required]
		[ForeignKey("Owner")]
		public int Owner_ID { get; set; }
		[Required]
		[ForeignKey("ExperienceType")]
		public int ExperienceType_ID { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public DateTime? DateBegin { get; set; }
		public DateTime? DateEnd { get; set; }


		public virtual ExperienceType ExperienceType { get; set; }
		public virtual Owner Owner { get; set; }
	}
}
