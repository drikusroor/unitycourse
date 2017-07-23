using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Application.LoadLevel(name);
    }

    public void Quit()
    {
        Debug.Log("Quit game requested.");
        Application.Quit();
    }

    public void LoadNextLevel()
    {

    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            print("You have won");
            LoadLevel("Win");
        }
    }

}
