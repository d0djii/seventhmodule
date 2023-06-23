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
    public Sprite Apple;
    public Sprite Orange;
    public Sprite Banana;
    public Sprite Pear;
}
