using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea1;
    public BoxCollider2D gridArea2;
    public int score;
    [SerializeField] Text scoreText;

    private BoxCollider2D currentGridArea;

    private void Start()
    {
        currentGridArea = gridArea1;
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = currentGridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
            GameHandler.Eat_Regular();

            if (GameHandler.GetScore() >= 100)
            {
                currentGridArea = gridArea2;
            }
        }
    }
}
