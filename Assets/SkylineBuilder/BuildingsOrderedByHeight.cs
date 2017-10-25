using System.Collections.Generic;
using System.Linq;

public class BuildingsOrderedByHeight
{
    public List<Building> Buildings { private get; set; }

    public Building GetHeighest()
    {
        return Buildings.LastOrDefault() ?? new Building { Height = 0};
    }

    public void AddBuilding(Building building)
    {
        Buildings.Add(building);
        Order();
    }
    
    public void RemoveBuilding(Building building)
    {
        Buildings.Remove(building);
        Order();
    }

    void Order()
    {
        Buildings = Buildings.OrderBy(b => b.Height).ToList();
    }
}