namespace SkylineBuilder
{
    public class AscendEvent : ChangeEvent
    {   
        public override void Process()
        {
            var heighestBuilding = OngoingBuildings.GetHeighest();
            if (OriginalBuilding.Height > heighestBuilding.Height)
                Output.Add(new PointOfChange
                {
                    X = X,
                    Y = OriginalBuilding.Height
                });
        
            OngoingBuildings.AddBuilding(OriginalBuilding);
        }
    }
}