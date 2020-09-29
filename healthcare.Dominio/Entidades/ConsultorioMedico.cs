namespace healthcare.Dominio.Entidades
{
    public class ConsultorioMedico
    {
        public int Id { get; set; }
        public int ConsultorioId { get; set; }
        public int MedicoId { get; set; }

        public Consultorio Consultorio { get; set; }
        public Medico Medico { get; set; }

        
    }
}
