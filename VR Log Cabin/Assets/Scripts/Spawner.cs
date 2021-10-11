using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    public float growTime;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(1.35f, 1.35f, 1.35f), growTime);
    }
}
