namespace ATCSHARP.Models {
    public class PacoteTuristico {

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public double Preco { get; set; }
        public DateTime? DeleteAt { get; set; }
        public List<Destino> Destinos { get; set; } = new();
        public List<Reserva> Reservas { get; set; } = new();

        //Esse "Action" já é um delegate do próprio .NET
        //public event Action<String> CapacityReached;

        public delegate void CapacityReachedDelegate(string mensagem);

        public event CapacityReachedDelegate CapacityReached;
        public void AdicionarReserva(Reserva reserva) {

            if (Reservas.Count >= CapacidadeMaxima) {

                CapacityReached?.Invoke("\nCapacidade máxima atingida para este pacote!");
                return;
            }
            Reservas.Add(reserva);
        }
    }
}
