using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Despawner : MonoBehaviour
{
    [SerializeField]
    private float timeToDespawn, growTime, shrinkTime;

    public Transform dissolveEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(timeToDespawn);

        transform.DOScale(new Vector3(0.08f, 0.24f, 0.08f), growTime).onComplete += Shrink;
    }

    void Shrink()
    {
        transform.DOScale(0.01f, shrinkTime).onComplete = () => { Destroy(gameObject); };
    }

    private void OnDestroy()
    {
        Instantiate(dissolveEffect, transform.position, transform.rotation);
    }
}
