namespace Task3.Containers;

public class CContainer : Container
{
    private Dictionary<string, double> _productsStandards = new Dictionary<string, double>();
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public CContainer(double containerMaxWeight, double height, double containerWeight, double depth) :
        base(containerMaxWeight, height, containerWeight, depth, "C")
    {
    }
    
    public void AddProductStandard(string product, double temperature)
    {
        _productsStandards.Add(product, temperature);
    }

    public void AddProduct(string product, double temperature)
    {
        foreach (var item in _productsStandards)
        {
            if (item.Key == product && item.Value > temperature)
            {
                throw new Exception("Temperature too low for the the required product");
            }
        }

        ProductType = product;
        Temperature = temperature;
    }

    public void LoadCContainer(double cargo, string typeCargo)
    {
        if (ProductType != typeCargo)
        {
            throw new Exception("Products types not match");
        }
        ContainerWeight += cargo;
    }
}