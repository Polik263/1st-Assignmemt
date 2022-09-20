using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndCamera : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private int playerIndex;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField] private float pitchClamp = 90;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                Vector3 direction = transform.right * Input.GetAxis("Horizontal");
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                Vector3 direction = transform.forward * Input.GetAxis("Vertical");
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }
        ReadRotationInput();
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


    private void ReadRotationInput()
    {
        if (playerTurn.IsPlayerTurn())
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

            characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
    } 

}
