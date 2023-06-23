using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler inst;

    private static int score;

    private void Awake() {
        inst = this;
    }

    public static int GetScore() {
        return score;
    }

    public static void Eat_Regular(){
        score += 5;
        Debug.Log(GetScore());
    }
    public static void Click_Regular(){
        score += 1;
        Debug.Log(GetScore());
    }
}
