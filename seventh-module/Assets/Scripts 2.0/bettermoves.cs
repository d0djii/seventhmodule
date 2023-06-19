using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bettermoves : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    void Awake()
    {
        transform.position = new Vector3(1,1,1);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving) {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if(Input.GetKey(KeyCode.S) && !isMoving) {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if(Input.GetKey(KeyCode.A) && !isMoving) {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if(Input.GetKey(KeyCode.D) && !isMoving) {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        


    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float ETime= 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(direction) - 90);
        while(ETime < timeToMove) {
            transform.position = Vector3.Lerp(origPos, targetPos, (ETime / timeToMove));
            ETime += Time.deltaTime;
            yield return null;
         }
        transform.position = targetPos;
        
        isMoving = false;
    }

    private float GetAngleFromVector(Vector3 d) {
        float n = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        if(n < 0)
            n += 360;
        return n;
    }
}
