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
    [Route("v1/objetivo")]
    public class ObjetivoController : Controller
    {
        IObjetivoRepository _objetivoRepository;

        public ObjetivoController(IObjetivoRepository objetivoRepository)
        {
            _objetivoRepository = objetivoRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult<Objetivo> GetById(int id)
        {
            var users = _objetivoRepository.Get(id);

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<Objetivo>> GetTodosObjetivos(int sobreClienteId)
        {
            var users = _objetivoRepository.GetTodosObjetivos(sobreClienteId);

            return users;
        }

        [HttpPost]
        [Route("")]
        //[AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public ActionResult<Objetivo> Post(
            [FromBody]Objetivo model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _objetivoRepository.Add(model);

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
        public ActionResult<Objetivo> Put(
            int id,
            [FromBody]Objetivo model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.SobreClienteId)
                return NotFound(new { message = "Usuário não encontrada" });

            try
            {

                _objetivoRepository.Edit(model);

                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public ActionResult<dynamic> Delete(int id)
        {
            try
            {
                _objetivoRepository.Delete(id);

                return new
                {
                    mensagem = "Registro Deletado com Sucesso"
                };
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover" });

            }
        }
    }
}