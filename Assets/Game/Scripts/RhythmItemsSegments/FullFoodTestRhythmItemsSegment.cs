namespace Game.Scripts.RhythmItemsSegments
{
    public class FullFoodTestRhythmItemsSegment : RhythmItemsSegment
    {
        private int _lines = 10;

        private SpeedType _speedType;
        
        public FullFoodTestRhythmItemsSegment(SpeedType speedType)
        {
            _speedType = speedType;
        }
        
        public bool HasNextItem()
        {
            return _lines >= 0;
        }

        public RhythmItemData GetNextItem()
        {
            _lines--;
            return new RhythmItemData(RhythmItemType.FOOD, RhythmItemType.FOOD, RhythmItemType.FOOD, RhythmItemType.FOOD);
        }

        public SpeedType GetSpeedType()
        {
            return _speedType;
        }
    }
}