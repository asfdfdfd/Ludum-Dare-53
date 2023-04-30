using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSegmentRhytmItemController : MonoBehaviour
{
    private RhythmItemsSegment _segment;

    public RhythmItemsSegment Segment => _segment;
    
    public void SetSegment(RhythmItemsSegment segment)
    {
        _segment = segment;
    }
}
