using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WordCorrectData
{
    public float timeTaken = 0;
    public string enteredString = string.Empty;
}

[System.Serializable]
public class UnityEventWordCorrect : UnityEvent<WordCorrectData> { }

/// <summary>
/// Global routing of game events
/// </summary>
public static class GlobalEvents
{
    public static UnityEventWordCorrect OnWordCorrect = new UnityEventWordCorrect();
}
