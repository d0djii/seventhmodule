using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInteraction : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    private bool canClickFruits = true;

    private void Update()
    {
        // Проверяем, является ли экран GameOver активным
        if (!GameOverScreen.gameObject.activeSelf && canClickFruits)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

                if (hitCollider != null)
                {
                    Food hitFood = hitCollider.GetComponent<Food>();
                    if (hitFood != null)
                    {
                        hitFood.RandomizePosition();
                        hitFood.score++;
                    }
                }
            }
        }
    }

    public void SetClickability(bool clickable)
    {
        canClickFruits = clickable;
    }
}
