using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Events : MonoBehaviour
{
    private GameObject objectToAlter;
    private Vector3 objectPos;
    private Quaternion objectRot;
    private Rigidbody rigidBody;

    public AudioSource buttonPress;

    private void Start()
    {
        objectToAlter = GameObject.FindGameObjectWithTag("Axe");
        rigidBody = objectToAlter.GetComponent<Rigidbody>();
        objectPos = objectToAlter.transform.position;
        objectRot = objectToAlter.transform.rotation;

    }

    public void OnPress(Hand hand)
    {
        objectToAlter.transform.position = objectPos;
        objectToAlter.transform.rotation = objectRot;
        rigidBody.velocity = Vector3.zero;
        buttonPress.Play();
    }
}
