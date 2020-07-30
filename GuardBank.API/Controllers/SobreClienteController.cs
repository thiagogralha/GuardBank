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
    [Route("v1/sobrecliente")]
    public class SobreClienteController : Controller
    {
        ISobreClienteRepository _sobreClienteRepository;

        public SobreClienteController(ISobreClienteRepository sobreClienteRepository)
        {
            _sobreClienteRepository = sobreClienteRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult<SobreCliente> GetById(int id)
        {
            var users = _sobreClienteRepository.Get(id);

            return users;
        }
       

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public ActionResult<SobreCliente> Post(
            [FromBody]SobreCliente model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Força o usuário a ser sempre "funcionário"
                model.Role = "employee";

                _sobreClienteRepository.Add(model);
                
                // Esconde a senha
                model.Senha = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(
                    [FromBody]SobreCliente model)
        {
            var user = _sobreClienteRepository.Authenticate(model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            // Esconde a senha
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }

    }
}