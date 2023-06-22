using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bettermoves : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 currentDirection = Vector3.zero;

    void Awake()
    {
        transform.position = new Vector3(0, 0, 1);
    }

    void Update()
    {
        
        if (!GameOverScreen.gameObject.activeSelf)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                if (currentDirection != Vector3.down)
                    currentDirection = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (currentDirection != Vector3.up)
                    currentDirection = Vector3.down;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (currentDirection != Vector3.right)
                    currentDirection = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (currentDirection != Vector3.left)
                    currentDirection = Vector3.right;
            }

            
            if (!isMoving)
            {
                StartCoroutine(MovePlayer(currentDirection));
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(direction) - 90);

        
        if (!CheckCollision(targetPos))
        {
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPos;
        }

        isMoving = false;
    }

    private float GetAngleFromVector(Vector3 d)
    {
        float n = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    private bool CheckCollision(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.01f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                GameOverScreen.Setup();
                return true; 
            }
        }
        return false; 
    }
}
