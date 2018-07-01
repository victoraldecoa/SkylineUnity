using System.Collections.Generic;

namespace SkylineBuilder
{
    public abstract class ChangeEvent
    {
        public IBuildingsOrderedByHeight OngoingBuildings { protected get; set; }
        public List<PointOfChange> Output { protected get; set; }
        public float X { get; set; }
        public Building OriginalBuilding { protected get; set; }

        public abstract void Process();
    }
}