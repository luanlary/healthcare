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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("VerificarConsultorio")]
        public ActionResult VerificarUsuario([FromBody] Consultorio consultorio)
        {
            try
            {
                var consultorioRetorno = _consultorioRepositorio.ObterPorNome(consultorio.Nome);

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
        public ActionResult Post([FromBody] Consultorio consultorio)
        {
            try
            {
                var consultorioCadastrado = _consultorioRepositorio.ObterPorNome(consultorio.Nome);

                if (consultorioCadastrado != null)
                    return BadRequest("Consultório já cadastrado no sistema");

                consultorio.Validate();

                if (!consultorio.EhValido)
                    return BadRequest(consultorio.ObterMensagensValidacao());
                
                _consultorioRepositorio.Adicionar(consultorio);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

