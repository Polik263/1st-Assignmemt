using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private List<PlayerTurn> playerTurns;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private TextMeshProUGUI seconds;
    [SerializeField] private List<Camera> cameras;



    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private float currentTurnTime;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            for (int i = 0; i < playerTurns.Count; i++)
            {
                playerTurns[i].SetPlayerTurn(i);
               // print(playerTurns[i].name + "   Player Index is: " + playerTurns[i].GetPlayerTurn());

            }
            currentPlayerIndex = 0;
            ChangeCamera();
        }
    }

    private void Update()
    {
        currentTurnTime += Time.deltaTime;
        seconds.text = Mathf.RoundToInt(maxTimePerTurn - currentTurnTime).ToString();

        if (currentTurnTime >= maxTimePerTurn)
        {
            waitingForNextTurn = true;
        }

        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
                currentTurnTime = 0;
                Restart();
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
        currentPlayerIndex++;
        currentPlayerIndex = currentPlayerIndex % playerTurns.Count;
        if (playerTurns[currentPlayerIndex].MV().enabled == false)
        {
            ChangeTurn();
        }
        ChangeCamera();

    }
    private void ChangeCamera()
    {
        for (int i = 0; i < playerTurns.Count; i++)
        {
            if (i == currentPlayerIndex)
            {
                playerTurns[i].GetCamera().enabled = true;
            }
            else
            {
                playerTurns[i].GetCamera().enabled = false;
            }
            /*if (playerTurns[currentPlayerIndex].enabled == false)
            {
                ChangeCamera();
            }*/

        }
    
    }

    public void Restart()
    {
        int playersLeft = playerTurns.Count;
        for (int i = 0; i < playerTurns.Count; i++)
        {
            if (playerTurns[i].MV().enabled == false)
            {
                playersLeft--;
            }
        }
        if (playersLeft <= 1)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}   
