using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;

    private Camera mainCamera;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(10,10), CursorMode.Auto);
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

            if (hitCollider != null)
            {
                Food hitFood = hitCollider.GetComponent<Food>();
                if (hitFood != null)
                {
                    hitFood.RandomizePosition();
                    // Здесь можно добавить любую другую логику, связанную с взаимодействием с фруктами
                }
            }
        }
    }


}
