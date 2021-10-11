using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backSawReached : MonoBehaviour
{
    public Sawing saw;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Saw" && saw.sawing)
        {
            saw.backReached++;
        }
    }
}
