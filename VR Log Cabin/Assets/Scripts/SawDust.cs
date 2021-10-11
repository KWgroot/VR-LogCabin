using UnityEngine;

public class SawDust : MonoBehaviour
{
    public Sawing saw;
    public Transform sawDustEffect;
    public AudioSource sawing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SawMiddle" && saw.sawing)
        {
            // Particle
            Instantiate(sawDustEffect, transform.position, transform.rotation);
            sawing.Play();
        }
    }
}
