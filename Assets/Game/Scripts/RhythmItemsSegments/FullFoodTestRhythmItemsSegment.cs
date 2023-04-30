namespace Game.Scripts.RhythmItemsSegments
{
    public class FullFoodTestRhythmItemsSegment : RhythmItemsSegment
    {
        public bool HasNextItem()
        {
            return true;
        }

        public RhythmItemData GetNextItem()
        {
            return new RhythmItemData();
        }
    }
}