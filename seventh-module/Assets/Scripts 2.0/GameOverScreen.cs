using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Timer timer;

    public void Setup()
    {
        gameObject.SetActive(true);
        timer.isTimerRunning = false;
    }
}
