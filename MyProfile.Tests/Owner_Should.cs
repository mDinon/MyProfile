using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProfile.API;
using MyProfile.API.Controllers;
using MyProfile.DAL;
using MyProfile.DAL.Repository;
using MyProfile.Model.DTO;
using MyProfile.Model.Entities;
using Xunit;

namespace MyProfile.Tests
{
	public class Owner_Should
	{
		DbContextOptions<MyProfileDbContext> _dbContextOptions;

		public Owner_Should()
		{
			_dbContextOptions = new DbContextOptionsBuilder<MyProfileDbContext>()
										.UseInMemoryDatabase(databaseName: "OwnerTest")
										.Options;
		}

		private IMapper CreateMapperConfig()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Owner, OwnerDto>();
				cfg.CreateMap<OwnerDto, Owner>();
				cfg.CreateMap<Address, AddressDto>();
				cfg.CreateMap<AddressDto, Address>();
				cfg.CreateMap<Contact, ContactDto>();
				cfg.CreateMap<ContactDto, Contact>();
				cfg.CreateMap<Experience, ExperienceDto>();
				cfg.CreateMap<ExperienceDto, Experience>();
				cfg.CreateMap<ExperienceType, ExperienceTypeDto>();
				cfg.CreateMap<ExperienceTypeDto, ExperienceType>();
				cfg.CreateMap<ContactType, ContactTypeDto>();
				cfg.CreateMap<ContactTypeDto, ContactType>();
			});

			return config.CreateMapper();
		}

		[Fact]
		public void PostOwner()
		{
			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				OwnerDto owner = new OwnerDto()
				{
					DateBirth = DateTime.Now,
					FirstName = $"Post",
					LastName = $"Test"
				};

				IActionResult result = myProfileController.PostOwner(owner);
				CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;
				OwnerDto ownerDtoResult = createdAtRouteResult.Value as OwnerDto;

				Assert.Equal("GetOwner", createdAtRouteResult.RouteName);
				Assert.Equal(201, createdAtRouteResult.StatusCode);
				Assert.NotNull(ownerDtoResult);
				Assert.Equal(1, ownerDtoResult.ID);
			}
		}

		[Fact]
		public async void GetOwners()
		{
			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				for (int i = 0; i < 10; ++i)
				{
					OwnerDto owner = new OwnerDto()
					{
						DateBirth = DateTime.Now,
						FirstName = $"Test{i}",
						LastName = $"{i}Test"
					};

					myProfileController.PostOwner(owner);
				}
			}

			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				IActionResult result = await myProfileController.GetOwners();
				OkObjectResult okResult = result as OkObjectResult;
				List<OwnerDto> owners = okResult.Value as List<OwnerDto>;

				Assert.NotNull(okResult);
				Assert.Equal(200, okResult.StatusCode);
				Assert.NotNull(owners);
				Assert.Equal(10, owners.Count);
			}
		}

		[Fact]
		public async void GetOwner()
		{
			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				for (int i = 0; i < 10; ++i)
				{
					OwnerDto owner = new OwnerDto()
					{
						DateBirth = DateTime.Now,
						FirstName = $"Test{i}",
						LastName = $"{i}Test"
					};

					myProfileController.PostOwner(owner);
				}
			}

			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				IActionResult result = await myProfileController.GetOwner(3);
				OkObjectResult okResult = result as OkObjectResult;
				OwnerDto owner = okResult.Value as OwnerDto;

				Assert.NotNull(okResult);
				Assert.Equal(200, okResult.StatusCode);
				Assert.NotNull(owner);
				Assert.Equal(3, owner.ID);
				Assert.Equal("Test2", owner.FirstName);
			}
		}

		[Fact]
		public async void PutOwner()
		{
			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				for (int i = 0; i < 10; ++i)
				{
					OwnerDto owner = new OwnerDto()
					{
						DateBirth = DateTime.Now,
						FirstName = $"Test{i}",
						LastName = $"{i}Test"
					};

					myProfileController.PostOwner(owner);
				}
			}

			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				IActionResult getResult = await myProfileController.GetOwner(3);
				OkObjectResult okResult = getResult as OkObjectResult;
				OwnerDto ownerDto = okResult.Value as OwnerDto;
				ownerDto.FirstName += "Updated";

				IActionResult result = await myProfileController.PutOwner(3, ownerDto);
				NoContentResult noContentResult = result as NoContentResult;

				IActionResult updatedResult = await myProfileController.GetOwner(3);
				okResult = updatedResult as OkObjectResult;
				OwnerDto ownerDtoUpdated = okResult.Value as OwnerDto;

				Assert.NotNull(noContentResult);
				Assert.Equal(204, noContentResult.StatusCode);
				Assert.Equal("Test2Updated", ownerDtoUpdated.FirstName);
			}
		}

		[Fact]
		public async void DeleteOwner()
		{
			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				for (int i = 0; i < 10; ++i)
				{
					OwnerDto owner = new OwnerDto()
					{
						DateBirth = DateTime.Now,
						FirstName = $"Test{i}",
						LastName = $"{i}Test"
					};

					myProfileController.PostOwner(owner);
				}
			}

			using (MyProfileDbContext context = new MyProfileDbContext(_dbContextOptions))
			{
				IMapper mapper = CreateMapperConfig();

				MyProfileController myProfileController = new MyProfileController(mapper, new OwnerRepository(context), new AddressRepository(context), new ContactRepository(context), new ExperienceRepository(context));

				IActionResult result = await myProfileController.DeleteOwner(3);
				NoContentResult noContentResult = result as NoContentResult;

				IActionResult getResult = await myProfileController.GetOwners();
				OkObjectResult okResult = getResult as OkObjectResult;
				List<OwnerDto> owners = okResult.Value as List<OwnerDto>;

				Assert.NotNull(noContentResult);
				Assert.Equal(204, noContentResult.StatusCode);
				Assert.Equal(9, owners.Count);
			}
		}
	}
}
