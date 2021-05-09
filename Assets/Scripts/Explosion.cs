using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Explosion")]
    public float explosionRadius;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoldOre")
            other.SendMessage("DestroyOre");
    }

}


