using UnityEngine;

namespace Game.Scripts.RhythmItemsSegments
{
    public class SlowRandomFoodOnly : RhythmItemsSegment
    {
        private int _lines = 3;

        public bool HasNextItem()
        {
            return _lines >= 0;
        }

        public RhythmItemData GetNextItem()
        {
            _lines--;

            var laneTypes = new RhythmItemType[4];
            
            var laneIndex = Random.Range(0, 4);
            for (int i = 0; i < 4; i++)
            {
                if (i != laneIndex)
                {
                    laneTypes[i] = RhythmItemType.NOTHING;
                }
                else
                {
                    laneTypes[i] = RhythmItemType.FOOD;
                }
            }
            
            return new RhythmItemData(laneTypes);
        }

        public SpeedType GetSpeedType()
        {
            return SpeedType.SLOW;
        }

        public float GetSpawnTime()
        {
            return 1.0f;
        }
    }
}