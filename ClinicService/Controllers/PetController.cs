﻿using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
        {
            int res = _petRepository.Create(new Pet
            {
                ClientId = createRequest.ClientId,
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updateRequest)
        {
            int res = _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClientId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        public ActionResult<int> Delete([FromQuery] int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all", Name = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }


        [HttpGet("get/{petId}")]
        public ActionResult<Pet> GetById([FromRoute] int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }
    }
}
