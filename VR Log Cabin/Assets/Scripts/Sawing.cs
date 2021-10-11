using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Sawing : MonoBehaviour
{
    private Collider saw;
    private GameObject spawnButton;

    public Transform plank;

    [HideInInspector]
    public int backReached = 0;

    [HideInInspector]
    public bool sawing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnButton = GameObject.FindGameObjectWithTag("LogSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (backReached >= 4)
        {
            sawing = false;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sawblade")
        {
            sawing = true;
            saw = other;
            saw.transform.parent.transform.rotation = this.transform.rotation;
            saw.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            saw.transform.parent.transform.position = new Vector3(-2f, 3.64f, 0.64f);
            saw.GetComponentInParent<LinearDrive>().repositionGameObject = true;
            saw.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("SawMiddle").GetComponent<BoxCollider>().enabled = true;
            if (saw.GetComponentInParent<Interactable>().attachedToHand != null)
                saw.GetComponentInParent<Interactable>().attachedToHand.DetachObject(other.transform.parent.gameObject, true);
        }
    }

    private void OnDestroy()
    {
        if (saw.GetComponentInParent<Rigidbody>().constraints != RigidbodyConstraints.None)
            saw.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        saw.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        saw.GetComponentInParent<LinearDrive>().repositionGameObject = false;
        saw.GetComponent<BoxCollider>().enabled = true;
        GameObject.FindGameObjectWithTag("SawMiddle").GetComponent<BoxCollider>().enabled = false;
        spawnButton.GetComponent<SpawnLog>().canSpawnLog();

        Instantiate(plank, transform.position, Quaternion.identity);
        Instantiate(plank, transform.position, Quaternion.identity);
    }
}
