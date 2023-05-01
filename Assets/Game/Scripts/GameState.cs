public class GameState
{
    public static int PointsCollected;

    public static float TreeSizeCurrent;
    public static float TreeSizeBest;

    public static bool ShouldStartGameplayRightNow = false;
    
    static public void ResetData()
    {
        PointsCollected = 0;
        TreeSizeCurrent = 0.0f;
    }
}