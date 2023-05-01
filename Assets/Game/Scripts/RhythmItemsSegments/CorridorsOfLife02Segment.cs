using System.Collections.Generic;

namespace Game.Scripts.RhythmItemsSegments
{
    public class CorridorsOfLife02Segment : RhythmItemsSegment
    {
        private SpeedType _speedType;

        private List<RhythmItemData> items = new List<RhythmItemData>()
        {
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FOOD,       RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FOOD,       RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,          RhythmItemType.NOTHING,       RhythmItemType.FOOD,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.NOTHING,       RhythmItemType.FOOD,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FOOD,          RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,          RhythmItemType.FOOD,       RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,          RhythmItemType.NOTHING,       RhythmItemType.FOOD,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,          RhythmItemType.NOTHING,       RhythmItemType.FOOD,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,          RhythmItemType.FOOD,       RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FOOD,       RhythmItemType.NOTHING,      RhythmItemType.NOTHING),
        };

        private int _currentIndex;
        
        public CorridorsOfLife02Segment(SpeedType speedType)
        {
            _speedType = speedType;
            _currentIndex = items.Count - 1;
        }
        
        public bool HasNextItem()
        {
            return _currentIndex > -1;
        }

        public RhythmItemData GetNextItem()
        {
            var item = items[_currentIndex];
            _currentIndex--;
            return item;
        }

        public SpeedType GetSpeedType()
        {
            return _speedType;
        }
    }
}