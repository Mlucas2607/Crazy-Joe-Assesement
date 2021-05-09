using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int healAmount;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.SendMessage("AddHealth",healAmount);
            Destroy(this.gameObject);
        }
    }
}
