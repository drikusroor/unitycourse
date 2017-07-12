using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;

    private enum State
    {
        cel_0, tuinslang_0, rooster_0, ets_0, knop_0,
        haar_0, schreeuw_0, rooster_1, ets_1, knop_1,
        corridor_0, exit_0
    }

    private State myState;

	// Use this for initialization
	void Start () {
        myState = State.cel_0;
	}

    // Update is called once per frame
    void Update () {
        print(myState);
        if (myState == State.cel_0)             cel_0();
        else if (myState == State.tuinslang_0)  tuinslang_0();
        else if (myState == State.ets_0)        ets_0();
        else if (myState == State.tuinslang_0)  tuinslang_0();
        else if (myState == State.knop_0)       knop_0();
        else if (myState == State.rooster_0)    rooster_0();
        else if (myState == State.haar_0)       haar_0();
        else if (myState == State.schreeuw_0)   schreeuw_0();
        else if (myState == State.rooster_1)    rooster_1();
        else if (myState == State.ets_1)        ets_1();
        else if (myState == State.knop_1)       knop_1();
        else if (myState == State.corridor_0)   corridor_0();
        else if (myState == State.exit_0)       exit_0();
    }

    #region state handler methods
    void cel_0 ()
    {
        text.text = "Je staat op je handen in een cel. " +
                    "Het stinkt naar rotte vis en andere dode diersoorten. " +
                    "Je ziet een ets aan de muur, een knop aan het plafond, en een rooster op de grond.\n\n" +
                    "Druk op E om de Ets te bekijken, K om de Knop te bekijken, T voor die kekke Tuinslang, en R om het Rooster te bekijken.";
        if (Input.GetKeyDown(KeyCode.E))        myState = State.ets_0;
        else if (Input.GetKeyDown(KeyCode.K))   myState = State.knop_0;
        else if (Input.GetKeyDown(KeyCode.T))   myState = State.tuinslang_0;
        else if (Input.GetKeyDown(KeyCode.R))   myState = State.rooster_0;
    }

    void ets_0()
    {
        text.text = "Je ziet een ets van een naakte man. " +
                    "Een vijgenblad voor z'n Peter Pan. " +
                    "Jouw eigen Peter Pan vindt het ook leuk en schaamt zich er niet voor, " +
                    "maar beter voel je je er niet van.\n\n" +
                    "Druk op C de cel weer te inspecteren.";
        if (Input.GetKeyDown(KeyCode.C)) myState = State.cel_0;
    }

    void knop_0()
    {
        text.text = "De knop ziet er rond, doch drukbaar uit. Rood en glanzend als een brandweerauto op een hete zomerdag. \n\n" +
                    "Druk op C de Cel weer te inspecteren, of druk op D voor een Druk op de glanzende rooie knop.";
        if (Input.GetKeyDown(KeyCode.C)) myState = State.cel_0;
        else if (Input.GetKeyDown(KeyCode.D)) myState = State.haar_0;
    }

    void rooster_0()
    {
        text.text = "Je staat op het rooster en je denkt: \n\n" + 
                    "\"Zou hier die vreemde graflucht vandaan komen?\" \n\n" +
                    "Druk op C de cel weer te beanalyseren als Co Adriaanse.";
        if (Input.GetKeyDown(KeyCode.C)) myState = State.cel_0;
    }

    void tuinslang_0()
    {
        text.text = "Je spuit wat rond met de tuinslang, " +
                    "het is niet erg leuk. \n\n" +
                    "Druk op C de cel weer te irriteren met je gezanik.";
        if (Input.GetKeyDown(KeyCode.C)) myState = State.cel_0;
    }

    void haar_0()
    {
        text.text = "Je drukt op het knopje en je haar vliegt in de fik!\n" +
                    "Oh, dat doet pijn! \n" +
                    "Oh, dat doet pijn! \n" +
                    "Heya-heya-hé! \n" +
                    "Heya-heya-hé! \n\n" +
                    "Druk op S om te Schreeuwen van de pijn of druk op T om jezelf te blussen met die kekke Tuinslang.";
        if (Input.GetKeyDown(KeyCode.T)) myState = State.cel_0;
        else if (Input.GetKeyDown(KeyCode.S)) myState = State.schreeuw_0;
    }

    void schreeuw_0()
    {
        text.text = "Je schreeuwt het uit want het doet zo'n pijn! " +
                    "Had je maar verdöving middels whiskey of wijn! \n\n" +
                    "Een bewaker staat plotseling in de deuropening. Hij pakt de slang en blust je kanis. \n\n" +
                    "Druk op R om hem het Rooster te laten zien, druk op E om hem de ets te laten zien, " +
                    "of tap D voor een ferme Druk op de knop."; 
        if (Input.GetKeyDown(KeyCode.R)) myState = State.rooster_1;
        else if (Input.GetKeyDown(KeyCode.E)) myState = State.ets_1;
        else if (Input.GetKeyDown(KeyCode.D)) myState = State.knop_1;
    }

    void rooster_1()
    {
        text.text = "Je laat het rooster zien om de lichaamsgeur van de bewaker te illustreren. " +
                    "De bewaker vindt het niet leuk, verlaat de cel en doet de deur op slot \n\n" +
                    "Je weet het ook niet meer... \n\n" +
                    "Druk op S om te slapen.";
        if (Input.GetKeyDown(KeyCode.S)) myState = State.cel_0;
    }

    void ets_1()
    {
        text.text = "Je laat de ets zien om het uiterlijk van de bewaker te illustreren. " +
                    "De bewaker vindt het leuk, dat zie je aan zijn zenuwachtige glimlach. " +
                    "Hij verlaat de cel en doet de deur NIET op slot \n\n" +
                    "Druk op V om de vrijheid te pakken of druk op C om jezelf weer op te sluiten.";
        if (Input.GetKeyDown(KeyCode.V)) myState = State.corridor_0;
        else if (Input.GetKeyDown(KeyCode.C)) myState = State.cel_0;
    }

    void knop_1()
    {
        text.text = "Je drukt op het knopje en zijn haar vliegt in de fik.\n" +
                    "Oh, dat doet pijn! \n" +
                    "Oh, dat doet pijn! \n" +
                    "Heya-heya-hé! \n" +
                    "Heya-heya-hé! \n\n" +
                    "Druk op K om de Kanis van de celbewaker te grinden in het rooster als een sigaret in een asbak - " +
                    "om vervolgens de vrijheid te pakkah, " +
                    "of druk op H om de celbewaker " +
                    "Hartmassage te geven, hem uit de cel te slepen, om vervolgens jezelf weer op te sluiten " +
                    "en te gaan slapen.";
        if (Input.GetKeyDown(KeyCode.K)) myState = State.corridor_0;
        else if (Input.GetKeyDown(KeyCode.H)) myState = State.cel_0;
    }

    void corridor_0()
    {
        text.text = "Je ruikt het. \n" +
                    "De geur van vrijheid. \n" +
                    "Het ruikt een beetje als te kort gefrituurde zeep. \n\n" +
                    "Maar je bent er nonnie helemaal. Je staat in een corridor. \n\n" +
                    "Druk op X om dit 'pelletje af te sluiten want ik ben te lui om de game af te maken " +
                    "en ik weet vrijwel zeker dat ik het wel snap.";
        if (Input.GetKeyDown(KeyCode.X)) myState = State.exit_0;
    }

    void exit_0()
    {
        Application.Quit();
    }
    #endregion
}
