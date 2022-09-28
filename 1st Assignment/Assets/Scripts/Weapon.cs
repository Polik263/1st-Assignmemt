using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private GameObject bazooka1;
    [SerializeField] private GameObject bazooka2;
    [SerializeField] private GameObject bazooka3;
    [SerializeField] private GameObject bazooka4;


    private void Start()
    {
        bazooka1.SetActive(false);
        bazooka2.SetActive(false);
        bazooka3.SetActive(false);
        bazooka4.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bool IsPlayerTurn = playerTurn.IsPlayerTurn();
            if (IsPlayerTurn)
            {
                TurnManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.transform.rotation = shootingStartPosition.rotation;
                newProjectile.GetComponent<Projectile>().Initialize();
            }
        }
    }

}


