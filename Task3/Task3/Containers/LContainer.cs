using Task3.Exceptions;

namespace Task3.Containers;

public class LContainer : Container, IHazardNotifier
{
    public bool HazardousCargo { get; set; }

    public LContainer(double containerMaxWeight, double height, double containerWeight, double depth, bool hazardousCargo) :
        base(containerMaxWeight, height, containerWeight, depth, "L")
    {
        HazardousCargo = hazardousCargo;
    }

    public override void LoadContainer(double cargo)
    {
        double containerLimit;
        if (HazardousCargo)
        {
            containerLimit = ContainerMaxWeight * 0.5;
        }
        else
        {
            containerLimit = ContainerMaxWeight * 0.9;
        }

        if (CargoWeight + cargo > containerLimit)
        {
            Notify($"Danger of liquid overfill at cargo:{SerialNumber}");
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
               $" Depth = {Depth} cm, Max Payload = {ContainerMaxWeight} kg, Hazardous = {HazardousCargo}";
    }
   
}