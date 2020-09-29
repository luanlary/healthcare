using System.Collections.Generic;

namespace healthcare.Dominio.Entidades
{
    public class Consultorio: Entidade
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ConsultorioMedico> ConsultorioMedicos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrWhiteSpace(this.Endereco))
                AdicionarCritica("O campo endereço é de preenchimento obrigatório!");

            if (string.IsNullOrWhiteSpace(this.Telefone))
                AdicionarCritica("O campo endereço é de preenchimento obrigatório!");
        }
    }
}
