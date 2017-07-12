using UnityEngine;
using System.Collections;

public class NumberKillers : MonoBehaviour {

    public int randomNumber;
    public int turns = 0;

    public int min = 1;
    public int max = 1000;
    public int guess = 500;


	// Use this for initialization
	void Start () {

        StartGame();

    }

    void StartGame()
    {
        min = 1;
        max = 1000;
        guess = 500;
        

        print("=============================================");
        print("Welcome to Number Wizard");
        print("Pick a number in you head, but do not tell me");

        print("The highest number you can pick is " + max.ToString());
        print("The lowest number you can pick is " + min.ToString());

        print("Is the number higher or lower than " + guess + "?");
        print("Up = for higher, down = lower, return = equal");

        max = max + 1;
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess);
        print("Up = for higher, down = lower, return = equal");
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("up");
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("down");
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
    }
}
