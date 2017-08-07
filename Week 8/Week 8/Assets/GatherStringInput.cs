using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gathers all user string based character input over time
/// </summary>
public class GatherStringInput : MonoBehaviour {
    public Text previewCurrentlyTypedText;

    public string userInput = string.Empty;

    void Update ()
    {
		// collect user string input and account for backspace

        if(string.IsNullOrEmpty(Input.inputString))
        {
            for (int i = 0; i <Input.inputString.Length; i++)
            {
                var ch = Input.inputString[i];

                if (ch == '\b')
                {
                    // remove last
                }
                else if
                    {

                }
            }
        }
	}
}
