using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthcare.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ConsultorioController: Controller
    {
        private readonly IConsultorioRepositorio _consultorioRepositorio;
        public ConsultorioController(IConsultorioRepositorio consultorioRepositorio)
        {
            this._consultorioRepositorio = consultorioRepositorio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var consultorioLista = _consultorioRepositorio.ObterTodos();
                if (consultorioLista != null)
                    return Json(consultorioLista);
                return BadRequest("Não há consultórios cadastrados!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Consultorio consultorio)
        {
            try
            {
                consultorio.Validate();
                if (!consultorio.EhValido)
                {
                    return BadRequest(consultorio.ObterMensagensValidacao());
                };

                if (consultorio.Id <= 0)
                {
                    _consultorioRepositorio.Adicionar(consultorio);
                }
                else
                {
                    _consultorioRepositorio.Atualizar(consultorio);
                }


                return Created("api/consultorio", consultorio);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("deletar")]
        public IActionResult deletar([FromBody] Consultorio consultorio)
        {
            try
            {
                _consultorioRepositorio.Remover(consultorio);
                return Json(_consultorioRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

