namespace SkylineBuilder
{
    public interface IBuildingsOrderedByHeight
    {
        Building GetHeighest();
        void AddBuilding(Building building);
        void RemoveBuilding(Building building);
    }
}