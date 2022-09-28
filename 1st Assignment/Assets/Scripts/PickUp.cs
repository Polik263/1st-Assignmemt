using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject bazookaPickUp;
    [SerializeField] private GameObject bazooka1;
    [SerializeField] private GameObject bazooka2;
    [SerializeField] private GameObject bazooka3;
    [SerializeField] private GameObject bazooka4;
    public Bazooka bazooka;
    public Weapon weapon;

    void Start()
    {
        bazooka.enabled = false;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player1")
        {
            bazookaPickUp.SetActive(false);
            bazooka1.SetActive(true);
            bazooka.enabled = true;
            weapon.enabled = false;
        }
        if (collision.collider.name == "Player2")
        {
            bazookaPickUp.SetActive(false);
            bazooka2.SetActive(true);
            bazooka.enabled = true;
            weapon.enabled = false;
        }
        if (collision.collider.tag == "Player3")
        {
            bazookaPickUp.SetActive(false);
            bazooka3.SetActive(true);
            bazooka.enabled = true;
            weapon.enabled = false;
        }
        if (collision.collider.tag == "Player4")
        {
            bazookaPickUp.SetActive(false);
            bazooka4.SetActive(true);
            bazooka.enabled = true;
            weapon.enabled = false;
        }
    }
}
