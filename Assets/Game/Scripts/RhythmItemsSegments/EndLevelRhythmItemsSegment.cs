namespace Game.Scripts.RhythmItemsSegments
{
    public class EndLevelRhythmItemsSegment : RhythmItemsSegment
    {
        private bool _hasNextItem = true;
        
        public bool HasNextItem()
        {
            return _hasNextItem;
        }

        public RhythmItemData GetNextItem()
        {
            _hasNextItem = false;
            
            return new RhythmItemData(RhythmItemType.LEVELEND, RhythmItemType.LEVELEND, RhythmItemType.LEVELEND,
                RhythmItemType.LEVELEND);
        }

        public SpeedType GetSpeedType()
        {
            return SpeedType.NORMAL;
        }
    }
}