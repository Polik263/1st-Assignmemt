using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private int playerIndex;
    [SerializeField] Camera myCamera;

    public void SetPlayerTurn(int index)
    {
        playerIndex = index;
    }

    public bool IsPlayerTurn()
    {
        return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
    }

    public int GetPlayerTurn()
    {
        return playerIndex;
    }

    public MovementAndCamera MV()
    {
        return GetComponent<MovementAndCamera>();
    }

    public Camera GetCamera()
    {
        return myCamera;
    }
    
}
