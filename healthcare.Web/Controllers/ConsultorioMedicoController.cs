using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Contexto;
using healthcare.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthcare.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ConsultorioMedicoController: Controller
    {
        private readonly IConsultorioMedicoRepositorio _consultorioMedicoRepositorio;
        private readonly HealthCareContexto _healthCareContexto;
        public ConsultorioMedicoController(IConsultorioMedicoRepositorio consultorioMedicoRepositorio, HealthCareContexto healthCareContexto)
        {
            this._consultorioMedicoRepositorio = consultorioMedicoRepositorio;
            this._healthCareContexto = healthCareContexto;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {  
                   var lista = (from ep in _healthCareContexto.ConsultorioMedico
                                  join e in _healthCareContexto.Consultorios on ep.ConsultorioId equals e.Id
                                  join t in _healthCareContexto.Medicos on ep.MedicoId equals t.Id
                                  
                                  select new
                                  {
                                      consultorioId = ep.ConsultorioId,
                                      medicoId = ep.MedicoId,
                                      NomeMedico = t.Nome,
                                      NomeConsultorio = e.Nome
                                  }).Take(100);
                return Json(lista);

                return BadRequest("Não há consultórios cadastrados!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("VerificarConsultorioMedico")]
        public ActionResult VerificarConsultorioMedico([FromBody] ConsultorioMedico consultoriomedico)
        {
            try
            {
                var consultorioRetorno = 0; //consultorioMedicoRepositorio.ObterPorNome(consultorio.Nome);

                if (consultorioRetorno != null)
                    return Ok(consultorioRetorno);

                return BadRequest("Consultório ou médico com dados inválidos");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultorioMedico consultoriomedico)
        {
            try
            {
                
                if (consultoriomedico.Id <= 0)
                {
                    
                    _consultorioMedicoRepositorio.Adicionar(consultoriomedico);
                }
                else
                {
                    _consultorioMedicoRepositorio.Atualizar(consultoriomedico);
                }


                return Ok(consultoriomedico);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("deletar")]
        public IActionResult deletar([FromBody] ConsultorioMedico consultoriomedico)
        {
            try
            {
                _consultorioMedicoRepositorio.Remover(consultoriomedico);
                return Json(_consultorioMedicoRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

