using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //доступные направления
    private bool right = true;
    private bool left = false;
    private bool up = true;
    private bool down = true;

    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;

    public Transform SegmentPrefab;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        //изменил правило передвижения змейки (нужна оптимизация (наверное))
        //Змейка не может резко повернуть назад
            if (Input.GetKeyDown(KeyCode.W)) {
                if (up) {
                    _direction = Vector2.up;
                    up = true;
                    down = false;
                    left = true;
                    right = true;
                }
            
        } else if (Input.GetKeyDown(KeyCode.S)) {
            if (down) {
                _direction = Vector2.down;
                down = true;
                up = false;
                right = true;
                left = true;
            }
            
        } else if (Input.GetKeyDown(KeyCode.A)) {
            if (left) {
                _direction = Vector2.left;
                left = true;
                right = false;
                up = true;
                down = true;
            }
            
        } else if (Input.GetKeyDown(KeyCode.D)) {
            if (right) {
                _direction = Vector2.right;
                right = true;
                left = false;
                up = true;
                down = true;
            }
        } else if (Input.GetKey("escape")) {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        for (int i=_segments.Count-1;i>0;i--)
        {
            _segments[i].position = _segments[i-1].position;
        }

        this.transform.position = new Vector3(
             Mathf.Round(this.transform.position.x)+ _direction.x,
             Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        ); 
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.SegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void Reset()
    {
        for (int i= 1 ; i < _segments.Count;i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle"){
            Reset();
        }
    }
}