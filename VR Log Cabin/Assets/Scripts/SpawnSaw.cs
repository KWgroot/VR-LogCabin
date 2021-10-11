using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpawnSaw : MonoBehaviour
{
    private GameObject objectToAlter;
    private Vector3 objectPos, objectScale;
    private Quaternion objectRot;
    private Rigidbody rigidBody;

    public AudioSource buttonPress;

    private void Start()
    {
        objectToAlter = GameObject.FindGameObjectWithTag("Saw");
        rigidBody = objectToAlter.GetComponent<Rigidbody>();
        objectPos = objectToAlter.transform.position;
        objectScale = new Vector3(1.5f, 1.5f, 1.5f);
        objectRot = objectToAlter.transform.rotation;

    }

    public void OnPress(Hand hand)
    {
        objectToAlter.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        objectToAlter.GetComponent<LinearDrive>().repositionGameObject = false;
        objectToAlter.GetComponentInChildren<BoxCollider>().enabled = true;
        
        objectToAlter.transform.position = objectPos;
        objectToAlter.transform.rotation = objectRot;
        objectToAlter.transform.localScale = objectScale;
        rigidBody.velocity = Vector3.zero;

        buttonPress.Play();
    }
}
