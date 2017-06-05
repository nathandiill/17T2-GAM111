using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 userInput;
    public float movementSpeed = 5.0f;

    public GameObject projectilePrefab;
    public GameObject[] Muzzles;
    public float projectileForce = 200f;

    public float fireInterval = 1f;
    private float timeUntilCanFire = 0f;

    public float speed = 1.5f;
    public GameObject prefab;

    void Start ()
    {
        // Retrieve the Ridgidbody from gameObject
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            var go = Instantiate(prefab, transform.position, q);
            go.GetComponent<Rigidbody2D>().AddForce(transform.position);
        }
        
        // Retrieve user input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        userInput = new Vector2(horizontal, vertical);

        /*
        var mousePos = Input.mousePosition;
        var camRay = Camera.main.ScreenPointToRay(mousePos);
        var playField = new Plane(Vector3.back, Vector3.zero);

        float outDist = 0;
        if (playField.Raycast(camRay, out outDist))
        {
            var hitPos = camRay.GetPoint(outDist);

            Debug.DrawLine(transform.position, hitPos, Color.cyan);

            var dif = hitPos - transform.position;

            // Give that to a new bullet as which way it needs to travel
            var bulletDirection = dif.normalized;
        }

        if (Input.GetMouseButtonDown(0)) && timeUntilCanFire <= 0)
            {
            // Weapon on cooldown
            timeUntilCanFire = fireInterval;

            // Select muzzle
            GameObject Muzzle = Muzzles[0];

            // Retrieve Location
            Vector3 muzzleLocation = Muzzle.transform.position;

            // Direction to fire
            Vector3 fireDirection = muzzleLocation - transform.position;

            // Instantiate the projectile
            GameObject newProjectile = Instantiate(projectilePrefab);

            // Position projectile at muzzle
            newProjectile.transform.position = muzzleLocation;

            // Retrieve Ridgid body for projectile
            Rigidbody2D projectileRB = newProjectile.GetComponent<Rigidbody2D>();

            // Launch
            projectileRB.AddForce(fireDirection.normalized * projectileForce);
        }
        */
    }

    void FixedUpdate ()
    {
        // Call movement in FixedUpdate
        Vector2 newPosition = transform.position;
        newPosition += userInput * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
