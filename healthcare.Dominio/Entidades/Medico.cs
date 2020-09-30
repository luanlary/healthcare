using System;
using System.Collections;
using System.Collections.Generic;

namespace healthcare.Dominio.Entidades
{
    public class Medico: Entidade
    {
        public int Id { get; set; }
        public string  Crm { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Decimal ValorConsulta { get; set; }
        public virtual ICollection<ConsultorioMedico> ConsultorioMedicos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if ((ConsultorioMedicos != null) && (ConsultorioMedicos.Count >= 2))
                AdicionarCritica("Um médico só pode estar relacionado a 2 (dois) consultórios!");
            
            if (string.IsNullOrWhiteSpace(this.Nome))
                AdicionarCritica("O campo nome é de preenchimento obrigatório!");

            if (string.IsNullOrWhiteSpace(this.Crm))
                AdicionarCritica("O campo CRM é de preenchimento obrigatório!"); 
                
        }
    }
}
