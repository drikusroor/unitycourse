using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    public int randomNumber;

    public int min = 1;
    public int max = 1000;
    public int guess = 500;

    public int maxGuessesAllowed = 10;

    public Text scoreDisplay;
    
    public AudioSource up;
    public AudioSource down;

	// Use this for initialization
	void Start () {
        StartGame();
    }

    void StartGame()
    {
        min = 1;
        max = 1000;
        NextGuess();

        max = max + 1;
    }

    public void GuessHigher()
    {
        up.Play();
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        down.Play();
        max = guess;
        NextGuess();
    }

    void GenerateGuess()
    {
        int typeGuess = Random.Range(0, 3);

        // Rational guess
        if (typeGuess == 0)
        {
            guess = (max + min) / 2;
        }
        // Random guess
        else if (typeGuess == 1)
        {
            guess = Random.Range(min, max + 1);
        }
        // Semi-rational
        else
        {
            int deviation = (int)Mathf.Ceil((max - min) / 5);
            int plusOrMinus = Random.Range(0, 2);
            if (plusOrMinus == 0) deviation = -deviation;
            guess = (max + min + 1) / 2 + deviation;
        }

        scoreDisplay.text = guess.ToString();
    }

    void NextGuess()
    {
        GenerateGuess();
        maxGuessesAllowed = maxGuessesAllowed - 1;
        if(maxGuessesAllowed <= 0)
        {
            Application.LoadLevel("Win");
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
    }
}
