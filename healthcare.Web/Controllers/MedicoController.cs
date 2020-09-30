using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace healthcare.Web.Controllers
{
    [Route("api/[Controller]")]
    public class MedicoController: Controller
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        public MedicoController(IMedicoRepositorio medicoRepositorio)
        {
            this._medicoRepositorio = medicoRepositorio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var consultorioLista = _medicoRepositorio.ObterTodos();
                if (consultorioLista != null)
                    return Json(consultorioLista);
                return BadRequest("Não há consultórios cadastrados!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("VerificarMedico")]
        public ActionResult VerificarUsuario([FromBody] Medico medico)
        {
            try
            {
                var consultorioRetorno = _medicoRepositorio.ObterPorCRM(medico.Crm);

                if (consultorioRetorno != null)
                    return Ok(consultorioRetorno);

                return BadRequest("Consultório com dados inválidos");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Medico medico)
        {
            try
            {
                medico.Validate();
                if (!medico.EhValido)
                {
                    return BadRequest(medico.ObterMensagensValidacao());
                };

                if (medico.Id <= 0)
                {
                    _medicoRepositorio.Adicionar(medico);
                }
                else
                {
                    _medicoRepositorio.Atualizar(medico);
                }


                return Created("api/medico", medico);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("deletar")]
        public IActionResult deletar([FromBody] Medico medico)
        {
            try
            {
                _medicoRepositorio.Remover(medico);
                return Json(_medicoRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

