﻿using UnityEngine;

public class AsteroidHazardScript : MonoBehaviour {

    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] GameObject brokenObject;

    private float destroyTime = 20.0f;

    int dmgAmt = 25;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start () {
        HazardManagerScript.asteroidCount++;
        transform.LookAt(HazardManagerScript.player.transform);
        Destroy(gameObject, destroyTime);
	}
	
	void FixedUpdate () {
        rb.AddForce(transform.forward * movementSpeed);
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealthScript.Instance.TakeDamage(dmgAmt);
        }

        
        Destroy(gameObject); //TODO: Implelemt proper broken prefab

    }

    private void OnDestroy()
    {
        HazardManagerScript.asteroidCount--;
    }
}
