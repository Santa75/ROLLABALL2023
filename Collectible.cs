using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
 

    void OnTriggerEnter (Collider target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}