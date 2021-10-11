using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopWood : MonoBehaviour
{
    public Transform log;
    public Transform blade;
    public Inventory inventory;
    public AudioSource woodChop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "CuttableTree")
        {
            Instantiate(log, blade.position, Quaternion.identity);
            woodChop.Play();
            inventory.IncreaseLogs();
        }
    }
}
