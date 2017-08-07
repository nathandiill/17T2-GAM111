using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Gathers all user string based character input over time
/// </summary>
public class GatherStringInput : MonoBehaviour
{
    public Text previewCurrentlyTypedText;

    [System.Serializable]
    public class UnityEventString : UnityEvent<string> { }

    //this is the public event to show in the inspector so other things can subscribe
    public UnityEventString OnEnter;
    public UnityEventString OnTextChanged;
    

    public string userInput = string.Empty;
    
	void Update ()
    {
		//collect user stringinput and account for backspace

        if(!string.IsNullOrEmpty(Input.inputString))
        {
            for (int i = 0; i < Input.inputString.Length; i++)
            {
                var ch = Input.inputString[i];

                if (ch == '\b')
                {
                    //remove last 
                    if (userInput.Length >= 1)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                    }
                }
                else if (ch == '\n' || ch == '\r')
                {
                    //newline, tell people we did that and then clear
                    OnEnter.Invoke(userInput);

                    //tmp clear string
                    userInput = string.Empty;
                }
                else
                {
                    userInput += ch;
                }
            }
            
            if (previewCurrentlyTypedText != null)
                previewCurrentlyTypedText.text = userInput;

            OnTextChanged.Invoke(userInput);
        }
	}
}
