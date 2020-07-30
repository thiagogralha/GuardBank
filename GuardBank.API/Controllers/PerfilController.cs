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
    [Route("v1/contascadastradas")]
    public class PerfilController : Controller
    {
        IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult<Perfil> GetById(int id)
        {
            var users = _perfilRepository.Get(id);

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Perfil> GetPerfilSobreCliente(int sobreClienteId)
        {
            var users = _perfilRepository.GetPerfilSobreCliente(sobreClienteId);

            return users;
        }

        [HttpPost]
        [Route("")]
        //[AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public ActionResult<Perfil> Post(
            [FromBody]Perfil model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _perfilRepository.Add(model);

                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }  
    }
}