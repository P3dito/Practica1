namespace Practica_1.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public class MonedaModel
    {
        public decimal MontoEnviado { get; set; }
        public decimal MontoRecibido { get; set; }
        public required string MonedaOrigen { get; set; }
        public required string MonedaDestino { get; set; }
    }

    public class ConfirmacionModel
    {
        public required string Nombre { get; set; }
        public required string Documento { get; set; }
        public required decimal MontoRecibido { get; set; }
        public required string MonedaDestino { get; set; }
    }
}
