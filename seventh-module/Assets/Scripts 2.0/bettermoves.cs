using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bettermoves : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Vector3 currentDirection = Vector3.zero; // Текущее направление движения

    void Awake()
    {
        transform.position = new Vector3(1, 1, 1);
    }

    void Update()
    {
        // Задаем текущее направление движения в зависимости от нажатой клавиши
        if (Input.GetKey(KeyCode.W))
        {
            currentDirection = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentDirection = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentDirection = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentDirection = Vector3.right;
        }

        // Если персонаж не движется, запускаем корутину движения
        if (!isMoving)
        {
            StartCoroutine(MovePlayer(currentDirection));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(direction) - 90);
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private float GetAngleFromVector(Vector3 d)
    {
        float n = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }
}
