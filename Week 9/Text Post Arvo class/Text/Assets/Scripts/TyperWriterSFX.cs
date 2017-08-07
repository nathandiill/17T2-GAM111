using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyperWriterSFX : MonoBehaviour
{
    public AudioClip typesfx, winWordShort, winWordLong, winWordSlow;
    public AudioSource source;

    public void OnEnable()
    {
        GlobalEvents.OnWordCorrect.AddListener(WordComplete);
    }

    public void OnDisable()
    {
        GlobalEvents.OnWordCorrect.RemoveListener(WordComplete);
    }

    public void WordComplete(WordCorrectData data)
    {
        //need length of word for which awesome noise to play
        if (data.timeTaken > 2)
        {
            source.PlayOneShot(winWordSlow);
        }
        else if (data.enteredString.Length < 6)
        {
            source.PlayOneShot(winWordShort);
        }
        else
        {
            source.PlayOneShot(winWordLong);
        }
    }

    public void Type(string s)
    {
        source.PlayOneShot(typesfx);
    }
}
