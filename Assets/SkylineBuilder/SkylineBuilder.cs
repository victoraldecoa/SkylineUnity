using System.Collections.Generic;
using System.Linq;

namespace SkylineBuilder
{
    public class SkylineBuilder
    {
        private IBuildingsOrderedByHeight BuildingsOrderedByHeight { get; set; }

        public SkylineBuilder(IBuildingsOrderedByHeight buildingsOrderedByHeight)
        {
            BuildingsOrderedByHeight = buildingsOrderedByHeight;
        }
        
        public IEnumerable<PointOfChange> Build(IEnumerable<Building> buildings)
        {
            var skyline = new List<PointOfChange>();
            var orderedBuildings = BuildingsOrderedByHeight;
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
}