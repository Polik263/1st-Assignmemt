using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
        projectileBody.AddForce (transform.forward* 500f);
         
    }

}
