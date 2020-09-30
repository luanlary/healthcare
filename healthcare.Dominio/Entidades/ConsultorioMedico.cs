namespace healthcare.Dominio.Entidades
{
    public class ConsultorioMedico: Entidade
    {
        public int Id { get; set; }
        public int ConsultorioId { get; set; }
        public int MedicoId { get; set; }

        public virtual Consultorio Consultorio { get; set; }
        public virtual Medico Medico { get; set; }

        public override void Validate()
        {
            //throw new System.NotImplementedException();
        }
    }
}
