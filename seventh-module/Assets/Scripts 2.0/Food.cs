using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public int score;
    [SerializeField] Text scoreText;
    private void Start()
    {
        RandomizePosition();
    }
    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
            score++;
        }       
    }
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
