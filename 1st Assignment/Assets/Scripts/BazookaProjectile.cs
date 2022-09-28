using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaProjectile : MonoBehaviour
{

    public Collider projectileCollider;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private bool isActive;

    public BazookaProjectile(bool isActive)
    {
        this.isActive = isActive;
    }

    public void Initialize()


    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 1000f);
        projectileBody.AddForce(transform.up * 80f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            projectileCollider.enabled = false;
        }
    }
}

