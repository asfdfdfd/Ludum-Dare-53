using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public interface RhythmItemsSegment
{
    bool HasNextItem();

    RhythmItemData GetNextItem();
}
