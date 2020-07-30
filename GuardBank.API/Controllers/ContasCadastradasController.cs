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
    public class ContasCadastradasController : Controller
    {
        IContasCadastradasRepository _contasCadastradasRepository;

        public ContasCadastradasController(IContasCadastradasRepository contasCadastradasRepository)
        {
            _contasCadastradasRepository = contasCadastradasRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult<ContasCadastradas> GetById(int id)
        {
            var users = _contasCadastradasRepository.Get(id);

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<ContasCadastradas>> GetTodasContasCadastradas(int sobreClienteId)
        {
            var users = _contasCadastradasRepository.GetTodasContasCadastradas(sobreClienteId);

            return users;
        }

        [HttpPost]
        [Route("")]
        //[AllowAnonymous]
        // [Authorize(Roles = "manager")]
        public ActionResult<ContasCadastradas> Post(
            [FromBody]ContasCadastradas model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _contasCadastradasRepository.Add(model);

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
        public ActionResult<ContasCadastradas> Put(
            int id,
            [FromBody]ContasCadastradas model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.SobreClienteId)
                return NotFound(new { message = "Usuário não encontrada" });

            try
            {

                _contasCadastradasRepository.Edit(model);

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
                _contasCadastradasRepository.Delete(id);

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