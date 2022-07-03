using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform playerArmature;

    public bool vehicleActive;
    bool isInTransition;
    public Transform seatPoint;
    public Vector3 sitingoffset;
    public Transform exitPoint;
    [Space]
    public float transitionSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (vehicleActive && isInTransition) Exit();
        else if (!vehicleActive && isInTransition) Enter();

        if (Input.GetKeyDown(KeyCode.E))
        {
            isInTransition = true;
        }
    }
    private void Enter()
    {
        //Disable Componentes
        playerArmature.GetComponent<CapsuleCollider>().enabled = false;
        playerArmature.GetComponent<Rigidbody>().useGravity = false;

        //Move obj to designated seat
        playerArmature.position = Vector3.Lerp(playerArmature.position, seatPoint.position + sitingoffset, transitionSpeed);
        playerArmature.rotation = Quaternion.Slerp(playerArmature.rotation, seatPoint.rotation, transitionSpeed);

        //Set obj animation to sitting
        playerArmature.GetComponentInChildren<Animator>().SetBool("Sitting", true);

        //The reset check
        if (playerArmature.position == seatPoint.position + sitingoffset)
        {
            isInTransition = false;
            vehicleActive = true;
        }

    }

    private void Exit()
    {
        //Move obj to designated exit point
        playerArmature.position = Vector3.Lerp(playerArmature.position, exitPoint.position, transitionSpeed);
        

        //Set obj animation to idle
        playerArmature.GetComponentInChildren<Animator>().SetBool("Sitting", false);

        //The reset check
        if (playerArmature.position == exitPoint.position + sitingoffset)
        {
            isInTransition = false;
            vehicleActive = true;
        }

        //Enable Components
        playerArmature.GetComponent<CapsuleCollider>().enabled = true;
        playerArmature.GetComponent<Rigidbody>().useGravity = true;
    }

    
}
