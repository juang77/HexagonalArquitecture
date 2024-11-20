namespace AppSell.Dominio.Entities;

public class SellDetail
{
    public Guid productId { get; set; }

    public Guid sellId { get; set; }

    public decimal unitCost { get; set; }

    public decimal unitPrice { get; set; }

    public int sellCuantity { get; set; }

    public decimal subTotalDS { get; set; }

    public decimal taxDS { get; set; }

    public decimal totalDS { get; set; }

    public Product Product { get; set; }

    public Sell Sell { get; set; }
}
