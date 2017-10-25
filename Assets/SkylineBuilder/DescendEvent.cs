using System;
using System.Linq;

public class DescendEvent : ChangeEvent
{
    public override void Process()
    {
        var highest = OngoingBuildings.GetHeighest();
        var thisIsHighest = Math.Abs(OriginalBuilding.Height - highest.Height) < 0.000001f;
        
        OngoingBuildings.RemoveBuilding(OriginalBuilding);
        if (!thisIsHighest) return;
        
        var newHeighest = OngoingBuildings.GetHeighest();
            
        Output.Add(new PointOfChange
        {
            X = X,
            Y = newHeighest.Height
        });
    }
}