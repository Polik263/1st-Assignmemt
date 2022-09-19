using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                Vector3 direction = Vector3.forward * Input.GetAxis("Vertical");
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }
    }
    


    private void Jump()
    {
        
        characterBody.AddForce(Vector3.up * 200f);
    }
    private bool IsTouchingFloor()
    {
        Vector3 position = transform.position + Vector3.down * 0.1f;
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.15f, Vector3.down, out hit, 0.1f);
    }
    
}