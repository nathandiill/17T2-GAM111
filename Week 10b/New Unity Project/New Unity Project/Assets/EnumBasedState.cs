using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumBasedState : MonoBehaviour
{
    public bool isGrounded;
    public bool hasJetpack;
    public bool isJetpacking;
    public bool hasTail;
    public bool isSwimming;

    public enum PowerUpState
    {
        Small,
        Big,
        Fire,
        Jetpack
    }

    public PowerUpState powerUpState = PowerUpState.Small;

    // Use this for initialization
    void Start () {
		
	}

    private void UpdateSmall()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (powerUpState)
        {
            case PowerUpState.Small:
                UpdateSmall();
                break;
            case PowerUpState.Big:
                break;
            case PowerUpState.Fire:
                break;
            case PowerUpState.Jetpack:
                break;
            default:
                break;
        }
         //if (isSwimming)
         //{

        //}
        //else
        //{
        //    if (isGrounded)
        //    {
        //        //grounded beh
        //        if (isJetpacking)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        //air control beh
        //        if (hasTail && !isJetpacking)
        //        {

        //        }
        //    }
        //}
    }
}
