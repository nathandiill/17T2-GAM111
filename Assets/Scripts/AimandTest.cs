using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimandTest : MonoBehaviour {
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        var mousePos = Input.mousePosition;
        var camRay = Camera.main.ScreenPointToRay(mousePos);
        var playField = new Plane(Vector3.back, Vector3.zero);

        float outDist = 0;
        if (playField.Raycast(camRay, out outDist))
        {
            var hitPos = camRay.GetPoint(outDist);

            Debug.DrawLine(transform.position, hitPos, Color.yellow);

            var dif = hitPos - transform.position;

            // Give that to a new bullet as which way it needs to travel
            var bulletDirection = dif.normalized;
        }
	}
}
