using System.Collections.Generic;

namespace Game.Scripts.RhythmItemsSegments
{
    public class CorridorsOfDeath01Segment : RhythmItemsSegment
    {
        private SpeedType _speedType;

        private List<RhythmItemData> items = new List<RhythmItemData>()
        {
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FAKE,       RhythmItemType.FAKE,      RhythmItemType.FAKE),
            new RhythmItemData(RhythmItemType.NOTHING,       RhythmItemType.FAKE,          RhythmItemType.FAKE,      RhythmItemType.FAKE),
            new RhythmItemData(RhythmItemType.FAKE,          RhythmItemType.NOTHING,       RhythmItemType.FAKE,      RhythmItemType.FAKE),
            new RhythmItemData(RhythmItemType.FAKE,          RhythmItemType.NOTHING,       RhythmItemType.FAKE,      RhythmItemType.FAKE),
            new RhythmItemData(RhythmItemType.FAKE,          RhythmItemType.FAKE,       RhythmItemType.NOTHING,      RhythmItemType.FAKE),
            new RhythmItemData(RhythmItemType.FAKE,          RhythmItemType.FAKE,       RhythmItemType.NOTHING,      RhythmItemType.FAKE),
        };

        private int _currentIndex;
        
        public CorridorsOfDeath01Segment(SpeedType speedType)
        {
            _speedType = speedType;
            _currentIndex = items.Count - 1;
        }
        
        public bool HasNextItem()
        {
            return _currentIndex > 0;
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