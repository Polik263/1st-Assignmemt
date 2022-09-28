using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Collider projectileCollider;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject bazooka1;
    [SerializeField] private GameObject bazooka2;
    [SerializeField] private GameObject bazooka3;
    [SerializeField] private GameObject bazooka4;
    private bool isActive;

    public Projectile(bool isActive)
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
