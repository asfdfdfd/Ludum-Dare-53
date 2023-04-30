namespace Game.Scripts.RhythmItemsSegments
{
    public class FullFoodTestRhythmItemsSegment : RhythmItemsSegment
    {
        private int _lines = 10;
        
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
            return SpeedType.FAST;
        }

        public float GetSpawnTime()
        {
            return 1.0f;
        }
    }
}