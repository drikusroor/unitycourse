using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
        Debug.Log("Level load requested for " + name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
