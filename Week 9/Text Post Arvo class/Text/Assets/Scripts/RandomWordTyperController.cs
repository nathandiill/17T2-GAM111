using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Compares user entered to randomly selected word from parser
/// </summary>
public class RandomWordTyperController : MonoBehaviour
{
    public Text text;
    public WordParser wordParser;
    public float startTime;

	// Use this for initialization
	void Start () {

        Invoke("ChooseNewWord", 0.5f);
    }
	
    public void ChooseNewWord()
    {
        text.text = wordParser.GetRandomWord();
        startTime = Time.timeSinceLevelLoad;
    }

    public void CompareWord(string typed)
    {
        if(text.text == typed)
        {
            Debug.Log("Winnar");

            var WCData = new WordCorrectData();
            WCData.enteredString = typed;
            WCData.timeTaken = Time.timeSinceLevelLoad - startTime;

            GlobalEvents.OnWordCorrect.Invoke(WCData);
            ChooseNewWord();
        }
        else
        {
            Debug.Log("WRONG, you lose sir");
        }
    }
}
