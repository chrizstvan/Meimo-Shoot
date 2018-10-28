using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pets : MonoBehaviour 
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody flying = gameObject.GetComponent<Rigidbody>();
            flying.useGravity = false;
            flying.AddForce(transform.up * 10);
        }
    }

    // Update is called once per frame
    void Update () 
    {
        if (transform.position.y > 5 || transform.position.y < -2)
        {
            Destroy(gameObject);
        }
	}
}
