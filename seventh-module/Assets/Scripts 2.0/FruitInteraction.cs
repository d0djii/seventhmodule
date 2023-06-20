using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInteraction : MonoBehaviour
{
    private void Update()
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
