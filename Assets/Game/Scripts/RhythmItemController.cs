using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmItemController : MonoBehaviour
{
    private bool _isFakeCat;

    public bool IsFakeCat => _isFakeCat;
    
    public void SetFakeCat()
    {
        _isFakeCat = true;
    }
}
