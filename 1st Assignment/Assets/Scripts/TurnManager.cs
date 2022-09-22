using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private PlayerTurn playerThree;
    [SerializeField] private PlayerTurn playerFour;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private Camera camOne;
    [SerializeField] private Camera camTwo;
    [SerializeField] private Camera camThree;
    [SerializeField] private Camera camFour;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
            playerThree.SetPlayerTurn(3);
            playerFour.SetPlayerTurn(4);
            ChangeCamera();
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
                ChangeCamera();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;
        }
        else if (currentPlayerIndex == 3)
        {
            currentPlayerIndex = 4;
        }
        else if (currentPlayerIndex == 4)
        {
            currentPlayerIndex = 1;
        }
    }
    private void ChangeCamera()
    {
        if (currentPlayerIndex == 1)
        {
            camOne.enabled = true;
            camTwo.enabled = false;
            camThree.enabled = false;
            camFour.enabled = false;
        }
        else if (currentPlayerIndex == 2)
        {
            camOne.enabled = false;
            camTwo.enabled = true;
            camThree.enabled = false;
            camFour.enabled = false;
        }
        else if (currentPlayerIndex == 3)
        {
            camOne.enabled = false;
            camTwo.enabled = false;
            camThree.enabled = true;
            camFour.enabled = false;
        }
        else if (currentPlayerIndex == 4)
        {
            camOne.enabled = false;
            camTwo.enabled = false;
            camThree.enabled = false;
            camFour.enabled = true;
        }
    }
}   
