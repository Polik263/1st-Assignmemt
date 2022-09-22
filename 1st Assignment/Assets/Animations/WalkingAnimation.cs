using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerTurn playerTurn;


    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (IsPlayerTurn )
        {

            bool isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

            animator.SetBool("isWalking", isWalking);

            animator.enabled = true;
        }
        else
        { 

            animator.enabled = false;
        }
    }
}
