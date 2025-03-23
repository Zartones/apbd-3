using Task3.Containers;

namespace Task3;

public class ContainerShip
{
    public List<Container> Containers = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(double maxSpeed, int maxContainers, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers ||
            TotalWeight(Containers) + container.ContainerWeight > MaxWeight)
        {
            throw new InvalidOperationException("Cannot load container: exceeds ship capacity.");
        }

        Containers.Add(container);
    }

    public void LoadContainerList(List<Container> containers)
    {
        if (Containers.Count + containers.Count >= MaxContainers ||
            TotalWeight(Containers) + TotalWeight(containers) > MaxWeight)
        {
            throw new InvalidOperationException("Cannot load container: exceeds ship capacity.");
        }

        foreach (var con in containers)
        {
            Containers.Add(con);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);

        if (container != null)
        {
            Containers.Remove(container);
        }
    }

    public void Replace(Container container, string serialNumber)
    {
        var con = Containers.Find(c => c.SerialNumber == serialNumber);
        if (con != null)
        {
            int index = Containers.IndexOf(con);
            Containers.Insert(index, container);
            Containers.Remove(con);
        }
    }

    public void TransferContainer(string serialNumber, ContainerShip ship)
    {
        var con = Containers.Find(c => c.SerialNumber == serialNumber);
        if (con != null)
        {
            ship.LoadContainer(con);
            Containers.Remove(con);
        }
    }

    private double TotalWeight(List<Container> containers)
    {
        double totalWeight = 0;
        foreach (var item in containers)
        {
            totalWeight += item.ContainerWeight;
        }

        return totalWeight;
    }

    public override string ToString()
    {
        return $"Container Ship: Max Speed = {MaxSpeed} knots, Max Containers = {MaxContainers}," +
               $" Total Weight = {TotalWeight(Containers)} kg";
    }
}