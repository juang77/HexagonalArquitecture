namespace AppSell.Dominio.Entities;

public class Product
{
    public Guid productId { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public decimal cost { get; set; }

    public decimal prise { get; set; }

    public int stock { get; set; }

    public List<SellDetail> sellDetails { get; set; }
}
