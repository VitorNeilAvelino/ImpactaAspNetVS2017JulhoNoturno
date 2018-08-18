using System;

namespace Oficina.Dominio
{
    public class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Placa { get; set; }
        public Modelo Modelo { get; set; }
        public int Ano { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        public string Observacao { get; set; }
    }
}