using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    private void Awake() {
        instance = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite snakeBody;
    public Sprite apple;
    public Sprite banana;
    public Sprite pear;
    public Sprite orange;
}
