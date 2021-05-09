using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public float fuseTime;

    public GameObject explosionPrefab;
    void Update()
    {
        fuseTime -= Time.deltaTime;

        if (fuseTime < 0)
            Detonate();
    }

    void Detonate()
    {
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
