using AutoMapper;
using MyProfile.Model.DTO;
using MyProfile.Model.Entities;

namespace MyProfile.API
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Owner, OwnerDto>();
			CreateMap<OwnerDto, Owner>();
			CreateMap<Address, AddressDto>();
			CreateMap<AddressDto, Address>();
			CreateMap<Contact, ContactDto>();
			CreateMap<ContactDto, Contact>();
			CreateMap<Experience, ExperienceDto>();
			CreateMap<ExperienceDto, Experience>();
			CreateMap<ExperienceType, ExperienceTypeDto>();
			CreateMap<ExperienceTypeDto, ExperienceType>();
			CreateMap<ContactType, ContactTypeDto>();
			CreateMap<ContactTypeDto, ContactType>();
		}
	}
}
