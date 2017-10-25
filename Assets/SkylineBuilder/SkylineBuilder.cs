using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkylineBuilder
{
    public List<PointOfChange> Build(List<Building> buildings)
    {
        var skyline = new List<PointOfChange>();
        var orderedBuildings = new BuildingsOrderedByHeight
        {
            Buildings = new List<Building>()
        };
        var events = new List<ChangeEvent>();

        foreach (var building in buildings)
        {
            events.Add(new AscendEvent
            {
                OngoingBuildings = orderedBuildings,
                OriginalBuilding = building,
                Output = skyline,
                X = building.Start
            });
            events.Add(new DescendEvent
            {
                OngoingBuildings = orderedBuildings,
                OriginalBuilding = building,
                Output = skyline,
                X = building.End
            });
        }

        events = events.OrderBy(e => e.X).ToList();
        
        foreach (var change in events)
        {
            change.Process();
        }
        
        return skyline;
    }
}