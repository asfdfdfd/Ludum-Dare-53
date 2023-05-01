namespace Game.Scripts.RhythmItemsSegments
{
    public class RandomFoodSegment : RhythmItemsSegment
    {
        private int _lines = 5;

        private SpeedType _speedType;

        private bool _hasRandomCat;

        private int _randomCatIndex;
        
        public RandomFoodSegment(bool hasRandomCat, SpeedType speedType)
        {
            _hasRandomCat = hasRandomCat;
            _speedType = speedType;

            if (hasRandomCat)
            {
                _randomCatIndex = GameState.Random.Next(0, _lines);
            }
        }
        
        public bool HasNextItem()
        {
            return _lines > 0;
        }

        public RhythmItemData GetNextItem()
        {
            _lines--;
            
            var laneIndex = GameState.Random.Next(0, 4);
            
            if (!_hasRandomCat)
            {
                return new RhythmItemData(RhythmItemType.FOOD, laneIndex);
            }
            else
            {
                if (_lines == _randomCatIndex)
                {
                    return new RhythmItemData(RhythmItemType.FAKE, laneIndex);    
                }
                else
                {
                    return new RhythmItemData(RhythmItemType.FOOD, laneIndex);
                }
            }
        }

        public SpeedType GetSpeedType()
        {
            return _speedType;
        }
    }
}