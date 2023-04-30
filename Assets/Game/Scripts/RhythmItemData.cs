namespace Game.Scripts
{
    public struct RhythmItemData
    {
        public RhythmItemType[] typesOnLanes;

        public RhythmItemData(RhythmItemType lane1, RhythmItemType lane2, RhythmItemType lane3, RhythmItemType lane4)
        {
            typesOnLanes = new[] {lane1, lane2, lane3, lane4};
        }
        
        public RhythmItemData(RhythmItemType[] typesOnLanesIn)
        {
            typesOnLanes = typesOnLanesIn;
        }
    }
}