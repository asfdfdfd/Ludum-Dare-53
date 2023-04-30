using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpaceToPlayAgain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameState.ResetData();

            SceneManager.LoadScene("GameplayScene2");
        }
    }
}
