using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpawnLog : MonoBehaviour
{
    public Inventory inventory;
    public Transform log, logSpawn;
    public AudioSource buttonPress;

    [HideInInspector]
    public bool logSpawned = true;

    public void canSpawnLog()
    {
        logSpawned = false;
        inventory.IncreasePlanks();
    }

    public void OnPress(Hand hand)
    {
        if (inventory.logs > 0 && !logSpawned)
        {
            Instantiate(log, logSpawn.position, logSpawn.rotation);
            buttonPress.Play();
            inventory.DecreaseLogs();
            logSpawned = true;
        }
    }
}
