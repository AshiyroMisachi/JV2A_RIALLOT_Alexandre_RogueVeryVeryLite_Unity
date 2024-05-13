using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    //speed value of the player
    [SerializeField]
    private float speed = 12f;

    //Reference of the CharacterController
    private CharacterController controller;


    [SerializeField] private Transform playerMesh;
    void Start()
    {
        //Get Reference from Component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Chek if the player need to move each frame
        Movement();

        Orientation();
    }

    private void Movement()
    {
        //Stock Axis value
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Make a vector 3 from Axis value before moving
        Vector3 move = transform.right * x + transform.forward * z;

        //Move the Player    Multiplied by the speed    And deltaTime to work with all frameRate
        controller.Move(move * speed * Time.deltaTime);
    }

    private void Orientation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 1;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.y = transform.position.y;

        playerMesh.LookAt(mouseWorldPosition);
    }
}
