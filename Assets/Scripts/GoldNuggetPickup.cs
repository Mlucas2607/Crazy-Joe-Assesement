using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNuggetPickup : MonoBehaviour
{
    [Header("Componenets")]
    public int score;

    private void Start()
    {
        score = 1;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.SendMessage("AddScore", score);
            Destroy(this.gameObject);
        }
    }


}
