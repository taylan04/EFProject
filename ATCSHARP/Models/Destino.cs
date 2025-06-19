namespace ATCSHARP.Models {
    public class Destino {

        public int Id { get; set; }
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; }
        public int CidadeDestinoId { get; set; }
        public CidadeDestino CidadeDestino { get; set; }

    }
}
