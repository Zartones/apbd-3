using Task3.Exceptions;

namespace Task3.Containers;

public class Container
{
    private static int _serialCounter = 0;
    private HashSet<string> _serialNumbers = new HashSet<string>();

    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double ContainerWeight { get; set; }
    public double Depth { get; set; }
    public string? SerialNumber { get; }
    public double ContainerMaxWeight { get; set; }

    public Container(double containerMaxWeight, double height, double containerWeight, double depth, string type)
    {
        ContainerMaxWeight = containerMaxWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = SerialNumberGenerator(type);
    }

    private string SerialNumberGenerator(string containerType)
    {
        string serNum;
        do
        {
            serNum = $"KON-{containerType}-{++_serialCounter}";
        } while (_serialNumbers.Contains(serNum));

        _serialNumbers.Add(serNum);
        return serNum;
    }


    public virtual void EmptyContainer()
    {
        ContainerWeight = 0;
    }

    public virtual void LoadContainer(double cargo)
    {
        if (CargoWeight + cargo > ContainerMaxWeight)
        {
            throw new OverfillException("Mass of the cargo is greater than the capacity of a given container!");
        }

        ContainerWeight += cargo;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber}: Cargo Mass = {ContainerWeight} kg," +
               $" Height = {Height} cm, Tare Weight = {ContainerWeight} kg," +
               $" Depth = {Depth} cm, Max Payload = {ContainerMaxWeight} kg";
    }
}