using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Splits a textasset string by newlines for random selection
/// </summary>
public class WordParser : MonoBehaviour {
    // text data or dictionary
    public TextAsset textDataSource;

    // collection of words
    public List<string> allWords = new List<string>();

    // what we seperate our string by
    private readonly char[] WORD_SEPERATOR = new char[] { '\n', ' ', '\r' };

    // get random word
    public string GetRandomWord()
    {
        var wordIndex = Random.Range(0, allWords.Count);

        return allWords[wordIndex];
    }

    // parse data source and create the list
    private void Start()
    {
        var stringArray = textDataSource.text.Split(WORD_SEPERATOR);

        // convert to list
        allWords = stringArray.ToList();

        // remove emptys
        allWords.RemoveAll(x => string.IsNullOrEmpty(x));
    }
}
