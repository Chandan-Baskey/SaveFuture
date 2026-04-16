using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y< -3.5f)
        {
           Destroy(gameObject);
        }

    }
}
