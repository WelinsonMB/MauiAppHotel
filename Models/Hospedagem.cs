public class Hospedagem
{
    public string Quarto { get; set; } = string.Empty;
    public int Adultos { get; set; }
    public int Criancas { get; set; }
    public DateTime Checkin { get; set; }
    public DateTime Checkout { get; set; }
    public double ValorTotal { get; set; }
}