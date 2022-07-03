using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjControl2 : MonoBehaviour
{
    public GameObject move;
    

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 15f;
   

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, steerAmount, 0 );
        transform.Translate(0, 0, moveAmount);
    }
}

