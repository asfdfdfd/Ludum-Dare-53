using UnityEngine;

namespace Game.Scripts.RhythmItemsSegments
{
    public class BabkaCrissCross : RhythmItemsSegment
    {
        private int _lines = 10;

        private bool _isCriss = false;

        private SpeedType _speedType;
        
        public BabkaCrissCross(SpeedType speedType)
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

            if (_isCriss)
            {
                _isCriss = false;
                return new RhythmItemData(RhythmItemType.NOTHING, RhythmItemType.FOOD, RhythmItemType.GRANDMA, RhythmItemType.NOTHING);
            }
            else
            {
                _isCriss = true;
                return new RhythmItemData(RhythmItemType.NOTHING, RhythmItemType.GRANDMA, RhythmItemType.FOOD, RhythmItemType.NOTHING);
            }
        }

        public SpeedType GetSpeedType()
        {
            return _speedType;
        }
    }
}