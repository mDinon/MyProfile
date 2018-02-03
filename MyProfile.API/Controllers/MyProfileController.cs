﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProfile.DAL.Repository;
using MyProfile.Model.DTO;
using MyProfile.Model.Entities;

namespace MyProfile.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class MyProfileController : Controller
	{
		#region Fields

		private readonly IMapper _mapper;
		private readonly IOwnerRepository _ownerRepository;
		private readonly IAddressRepository _addressRepository;
		private readonly IContactRepository _contactRepository;
		private readonly IExperienceRepository _experienceRepository;

		#endregion

		#region Constructor

		public MyProfileController(IMapper mapper, IOwnerRepository ownerRepository, IAddressRepository addressRepository, IContactRepository contactRepository, IExperienceRepository experienceRepository)
		{
			_mapper = mapper;
			_ownerRepository = ownerRepository;
			_addressRepository = addressRepository;
			_contactRepository = contactRepository;
			_experienceRepository = experienceRepository;
		}

		#endregion

		#region Owners

		#region Get

		[HttpGet("owners")]
		public async Task<IActionResult> GetOwners()
		{
			List<Owner> owners = await _ownerRepository.GetListAsync();

			owners.Add(new Owner()
			{
				LastName = "Prezime",
				FirstName = "Ime",
				DateBirth = DateTime.Now,
				ID = 1
			});

			return new JsonResult(_mapper.Map<List<Owner>, List<OwnerDto>>(owners));
		}

		[HttpGet("owner/{id}", Name = "GetOwner")]
		public async Task<IActionResult> GetOwner(int id)
		{
			Owner owner = await _ownerRepository.FindAsync(id);

			if (owner == null)
				return NotFound();

			return new JsonResult(_mapper.Map<Owner, OwnerDto>(owner));
		}

		#endregion

		#region Post

		[HttpPost("owner")]
		public async Task<IActionResult> PostOwner([FromBody] OwnerDto ownerDto)
		{
			if (ownerDto == null)
				return BadRequest();

			Owner owner = _mapper.Map<OwnerDto, Owner>(ownerDto);

			bool isOk = await TryUpdateModelAsync(owner);

			if (!isOk || !ModelState.IsValid)
				return BadRequest(ModelState);

			Owner result = _ownerRepository.Add(owner);

			return CreatedAtRoute("GetOwner", new { id = result.ID }, _mapper.Map<Owner, OwnerDto>(result));
		}

		#endregion

		#region Put

		[HttpPut("owner/{id}")]
		public async Task<IActionResult> PutOwner(int id, [FromBody] OwnerDto ownerDto)
		{
			if (ownerDto == null || ownerDto.ID != id)
				return BadRequest();

			Owner updatedOwner = _mapper.Map<OwnerDto, Owner>(ownerDto);

			bool isOk = await TryUpdateModelAsync(updatedOwner);

			if (!isOk || !ModelState.IsValid)
				return BadRequest(ModelState);

			Owner owner = await _ownerRepository.FindAsync(id);

			if (owner == null)
				return NotFound();

			owner.DateBirth = updatedOwner.DateBirth;
			owner.FirstName = updatedOwner.FirstName;
			owner.LastName = updatedOwner.LastName;

			_ownerRepository.Update(owner);

			return NoContent();
		}

		#endregion

		#region Delete

		[HttpDelete("owner/{id}")]
		public async Task<IActionResult> DeleteOwner(int id)
		{
			Owner owner = await _ownerRepository.FindAsync(id);

			if (owner == null)
				return NotFound();

			_ownerRepository.Delete(owner);

			return NoContent();
		}

		#endregion

		#endregion

		#region Address

		#region Get

		[HttpGet("owner/{ownerId}/address")]
		public async Task<IActionResult> GetOwnerAddresses(int ownerId)
		{
			List<Address> addresses = await _addressRepository.GetListAsync(ownerId);

			return new JsonResult(_mapper.Map<List<Address>, List<AddressDto>>(addresses));
		}

		[HttpGet("owner/{ownerId}/address/{id}", Name = "GetAddressByID")]
		public async Task<IActionResult> GetAddressByID(int id)
		{
			Address addresses = await _addressRepository.FindAsync(id);

			if (addresses == null)
				return NotFound();

			return new JsonResult(_mapper.Map<Address, AddressDto>(addresses));
		}

		#endregion

		#region Post

		[HttpPost("owner/{ownerId}/address")]
		public async Task<IActionResult> PostAddress(int ownerId, [FromBody] AddressDto addressDto)
		{
			if (addressDto == null)
			{
				return BadRequest();
			}

			Address address = _mapper.Map<AddressDto, Address>(addressDto);
			address.Owner_ID = ownerId;

			bool isOk = await TryUpdateModelAsync(address);

			if (!isOk || !ModelState.IsValid)
				return BadRequest(ModelState);

			Address result = _addressRepository.Add(address);

			return CreatedAtRoute("GetAddressByID", new { ownerId = result.Owner_ID, id = result.ID }, _mapper.Map<Address, AddressDto>(result));
		}

		#endregion

		#region Put

		[HttpPut("owner/{ownerId}/address/{id}")]
		public async Task<IActionResult> PutAddress(int id, [FromBody] AddressDto addressDto)
		{
			if (addressDto == null || addressDto.ID != id)
				return BadRequest();

			Address updatedAddress = _mapper.Map<AddressDto, Address>(addressDto);

			bool isOk = await TryUpdateModelAsync(updatedAddress);

			if (!isOk || !ModelState.IsValid)
				return BadRequest(ModelState);

			Address address = await _addressRepository.FindAsync(id);

			if (address == null)
				return NotFound();

			address.Country = updatedAddress.Country;
			address.PostalCode = updatedAddress.PostalCode;
			address.Street = updatedAddress.Street;
			address.Town = updatedAddress.Town;

			_addressRepository.Update(address);

			return NoContent();
		}

		#endregion

		#region Delete

		[HttpDelete("owner/{ownerId}/address/{id}")]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			Address address = await _addressRepository.FindAsync(id);

			if (address == null)
				return NotFound();

			_addressRepository.Delete(address);

			return NoContent();
		}

		#endregion

		#endregion

		#region Contact



		#endregion

		#region Experience



		#endregion
	}
}