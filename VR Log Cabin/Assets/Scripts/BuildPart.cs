using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BuildPart : MonoBehaviour
{
    public Transform walls;
    public Transform roof;
    public Transform door;
    public Transform spawnLocation;
    public Transform doorSpawn;
    public Inventory inventory;
    public AudioSource appearSound;

    private int partToPlace = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress(Hand hand)
    {
        switch (partToPlace)
        {
            case 0:
                if (inventory.planks >= 20)
                {
                    Instantiate(walls, spawnLocation.position, spawnLocation.rotation);
                    inventory.DecreasePlanks(20);
                    partToPlace++;
                    appearSound.Play();
                }
                break;

            case 1:
                if (inventory.planks >= 10)
                {
                    Instantiate(roof, spawnLocation.position + new Vector3(0, 0.93f, 0), spawnLocation.rotation);
                    inventory.DecreasePlanks(10);
                    partToPlace++;
                    appearSound.Play();
                }
                break;

            case 2:
                if (inventory.planks >= 6)
                {
                    Instantiate(door, doorSpawn.position, doorSpawn.rotation);
                    inventory.DecreasePlanks(6);
                    partToPlace++;
                    appearSound.Play();
                }
                break;

            default:
                inventory.EndGame();
                break;
        }
    }
}
