using UnityEngine;

namespace Game.Scripts.RhythmItemsSegments
{
    public class BabkaLovushkaDjockera : RhythmItemsSegment
    {
        private int _lines = 30;

        private int _currentLane = -1;

        private int _linesInLane = -1;
        
        private bool _isCriss = false;
        
        public bool HasNextItem()
        {
            return _lines >= 0;
        }

        public RhythmItemData GetNextItem()
        {
            _lines--;

            if (_linesInLane == -1)
            {
                _currentLane = Random.Range(0, 4);
                _linesInLane = 10;
            }

            var typesIn = new RhythmItemType[4];

            for (int i = 0; i < 4; i++)
            {
                if (i == _currentLane)
                {
                    if (_linesInLane == 10 || _linesInLane == 0)
                    {
                        typesIn[i] = RhythmItemType.GRANDMA;
                    }
                    else
                    {
                        typesIn[i] = RhythmItemType.FOOD;
                    }
                }
            }
            
            _linesInLane--;
            
            return new RhythmItemData(typesIn);
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