using Task3.Exceptions;

namespace Task3.Containers;

public class GContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GContainer(double containerMaxWeight, double height, double containerWeight, double depth, double pressure) :
        base(containerMaxWeight, height, containerWeight, depth, "G")
    {
        Pressure = pressure;
    }

    public override void EmptyContainer()
    {
        ContainerWeight = CargoWeight * 0.05;
    }

    public override void LoadContainer(double cargo)
    {
        if (CargoWeight + cargo > ContainerMaxWeight)
        {
            Notify($"Danger of gas overfill at cargo:{SerialNumber}");
            throw new OverfillException("Mass of the cargo is greater than the capacity of a given container!");
        }

        CargoWeight += cargo;
    }

    public void Notify(string msg)
    {
        Console.WriteLine($"Hazardous situation happened: {msg}");
    }
    
    public override string ToString()
    {
        return $"Container {SerialNumber}: Cargo Mass = {ContainerWeight} kg," +
               $" Height = {Height} cm, Tare Weight = {ContainerWeight} kg," +
               $" Depth = {Depth} cm, Max Payload = {ContainerMaxWeight} kg, Pressure = {Pressure}";
    }
}