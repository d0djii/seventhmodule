using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Food : MonoBehaviour
{
    [SerializeField] GameObject[] Fruits;
    public BoxCollider2D gridArea;

    public GameObject Fruit;

    public static Food i;

    private void Awake(){
        i = this;
    }
    private void Start()
    {
        Spawn_Food();
        Spawn_Food();
        Spawn_Food();
        Spawn_Food();
        Spawn_Food();
    }
    public void Spawn_Food()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        int rand = Random.Range(0,Fruits.Length - 1);
        var position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        Fruit = Instantiate(Fruits[rand], position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Destroy(Fruit);
            GameHandler.Eat_Regular();
            Spawn_Food();
            
        }       
    }
}