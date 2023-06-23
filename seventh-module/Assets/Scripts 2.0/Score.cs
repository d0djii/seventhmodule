using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText;
    private void Awake() {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    private void Update() {
        scoreText.text = GameHandler.GetScore().ToString();
    }
}
