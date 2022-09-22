using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Collider projectileCollider;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
    private bool isActive;

    public Projectile(bool isActive)
    {
        this.isActive = isActive;
    }

    public void Initialize()
   
 
    { 
        isActive = true;
        projectileBody.AddForce (transform.forward * 700f);
        projectileBody.AddForce(transform.up * 100);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            projectileCollider.enabled = false;
        }
    }
}
