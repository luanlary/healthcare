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
        public virtual ICollection<Consultorio> Consultorios { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (Consultorios.Count >= 2)
                AdcionarCritica("Um médico só pode estar relacionado a 2 (dois) consultórios!");
            
            if (string.IsNullOrWhiteSpace(this.Nome))
                AdcionarCritica("O campo nome é de preenchimento obrigatório!");

            if (string.IsNullOrWhiteSpace(this.Crm))
                AdcionarCritica("O campo CRM é de preenchimento obrigatório!"); 
                
        }
    }
}
