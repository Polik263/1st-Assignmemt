using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Transform bazookaShootingStartPosition;
    [SerializeField] private GameObject bazooka1;
    [SerializeField] private GameObject bazooka2;
    [SerializeField] private GameObject bazooka3;
    [SerializeField] private GameObject bazooka4;
    [SerializeField] private GameObject bazookaProjectilePrefab;
    [SerializeField] private GameObject bazookaPickUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            bool IsPlayerTurn = playerTurn.IsPlayerTurn();
            if (IsPlayerTurn)
            {
                TurnManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(bazookaProjectilePrefab);
                newProjectile.transform.position = bazookaShootingStartPosition.position;
                newProjectile.transform.rotation = bazookaShootingStartPosition.rotation;
                newProjectile.GetComponent<BazookaProjectile>().Initialize();
            }
        }
    }

}
