namespace AppSell.Dominio.Entities;

public class Sell
{
    public Guid sellId { get; set; }

    public long numberSell { get; set; }

    public DateTime dateSell { get; set; }

    public string concept { get; set; }

    public decimal subTotalSell { get; set; }

    public decimal taxSell { get; set; }

    public decimal totalSell { get; set; }

    public bool Canceled { get; set; }

    public List<SellDetail> sellDetails { get; set; }
}
