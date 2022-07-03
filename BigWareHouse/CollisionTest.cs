using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    
    void OncollisionEnter(Collider other)
    {
        if(other.gameObject.tag == "Package")
        {
            Debug.Log("You are bumped");
        }
    }

    
}
