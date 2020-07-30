using GuardBank.API.Entities;
using GuardBank.API.Repository;
using GuardBank.API.Repository.Interfaces;
using GuardBank.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GuardBank.API.Controllers
{
    [Route("v1/endereco")]
    public class EnderecoController : Controller
    {
        IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult<Endereco> GetById(int id)
        {
            var users = _enderecoRepository.Get(id);

            return users;
        }
       

        [HttpPost]
        [Route("")]
        //[AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public ActionResult<Endereco> Post(
            [FromBody]Endereco model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _enderecoRepository.Add(model);

                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        //[Authorize(Roles = "manager")]
        public ActionResult<Endereco> Put(
            int id,
            [FromBody]Endereco model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.SobreClienteId)
                return NotFound(new { message = "Usuário não encontrada" });

            try
            {

                _enderecoRepository.Edit(model);

                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }
      
    }
}