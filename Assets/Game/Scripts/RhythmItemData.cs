namespace Game.Scripts
{
    public struct RhythmItemData
    {
        public RhythmItemType[] type;

        public RhythmItemData(RhythmItemType lane1, RhythmItemType lane2, RhythmItemType lane3, RhythmItemType lane4)
        {
            type = new[] {lane1, lane2, lane3, lane4};
        }
    }
}