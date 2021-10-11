using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource spawnSound;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnSound.Play();
    }
}
