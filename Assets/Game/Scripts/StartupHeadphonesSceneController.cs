using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupHeadphonesSceneController : MonoBehaviour
{
    private bool _hasPressedSpace;

    private void Update()
    {
        if (!_hasPressedSpace && Input.GetKeyDown(KeyCode.Space))
        {
            _hasPressedSpace = true;
        }
    }
}
