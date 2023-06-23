using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    private static int score;
    private static bool wallsRemoved;
    public GameObject[] wallsToRemove;

    private void Awake()
    {
        instance = this;
        wallsRemoved = false;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void Eat_Regular()
    {
        score += 5;
        Debug.Log("Score: " + score);

        if (score >= 100 && !wallsRemoved)
        {
            instance.RemoveWalls();
            wallsRemoved = true;
        }
    }

    public static void Click_Regular()
    {
        score += 1;
        Debug.Log("Score: " + score);
    }

    private void RemoveWalls()
    {
        foreach (GameObject wall in wallsToRemove)
        {
            Destroy(wall);
        }
    }
}
