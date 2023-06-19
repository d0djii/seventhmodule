using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    
    private Vector3Int gridMoveDirection;
    private Vector3Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    private void Awake() {
        gridPosition = new Vector3Int(0, 0, 1);
        gridMoveTimerMax = .5f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector3Int (1, 0, 1);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            if(gridMoveDirection.y != -1) {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if(gridMoveDirection.y != +1) {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if(gridMoveDirection.x != -1) {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if(gridMoveDirection.x != +1) {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }

        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax) {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPosition.x, gridPosition.y, gridPosition.z);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
        }
        
    }

    private float GetAngleFromVector(Vector3Int d) {
        float n = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        if(n < 0)
            n += 360;
        return n;
    }
}