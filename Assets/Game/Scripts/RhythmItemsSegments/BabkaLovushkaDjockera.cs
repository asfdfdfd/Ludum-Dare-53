using System;
using System.Collections.Generic;

namespace Game.Scripts.RhythmItemsSegments
{
    public class BabkaLovushkaDjockera : RhythmItemsSegment
    {
        private struct RhythmItemPack
        {
            public int LaneIndex;
            public List<RhythmItemType> Lines;
        }
        
        private List<RhythmItemPack> packs = new();
        
        private const int LINES_IN_PACK_FROM = 3;
        private const int LINES_IN_PACK_TO = 5;
        
        private const int PACKS_COUNT_FROM = 2;
        private const int PACKS_COUNT_TO = 5;
        
        private bool _hasNextItem = true;

        private int _currentPack;
        private int _currentLine;

        private Random _random = new();
        
        private SpeedType _speedType;

        public BabkaLovushkaDjockera(SpeedType speedType)
        {
            _speedType = speedType;
            
            int packsCount = _random.Next(PACKS_COUNT_FROM, PACKS_COUNT_TO);

            for (int i = 0; i < packsCount; i++)
            {
                int linesInPack = _random.Next(LINES_IN_PACK_FROM, LINES_IN_PACK_TO);
                int laneIndex = _random.Next(0, 4);

                List<RhythmItemType> items = new List<RhythmItemType>();
                
                items.Add(RhythmItemType.GRANDMA);

                for (int j = 0; j < linesInPack ; j++)
                {
                    items.Add(RhythmItemType.FOOD);
                }
                
                items.Add(RhythmItemType.GRANDMA);

                packs.Add(new RhythmItemPack { LaneIndex = laneIndex, Lines = items });
            }
        }
        
        public bool HasNextItem()
        {
            return _currentPack < packs.Count;
        }

        public RhythmItemData GetNextItem()
        {
            var pack = packs[_currentPack];
            var item = pack.Lines[_currentLine];
            var laneIndex = pack.LaneIndex;

            _currentLine++;
            if (_currentLine == pack.Lines.Count)
            {
                _currentLine = 0;
                _currentPack++;
            }

            return new RhythmItemData(item, laneIndex);
        }

        public SpeedType GetSpeedType()
        {
            return _speedType;
        }
    }
}