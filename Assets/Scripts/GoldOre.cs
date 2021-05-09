using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOre : MonoBehaviour
{
    [Header("GoldOre Drops")]
    public int maxGoldDrop, minGoldDrop;
    public float rndPosRng;
    public float rndRotRng;
    public GameObject[] goldDrops;

    private void Start()
    {
        maxGoldDrop = 6;
        minGoldDrop = 1;
        rndPosRng = 3;
        rndRotRng = 90;
    }

    public void DestroyOre()
    {
        int drpAmt = Random.Range(minGoldDrop, maxGoldDrop);
        Debug.Log("Gold Ore Dropped " + drpAmt + " Gold Pieces");
        for (int i = 0; i < drpAmt; i++)
        {
            //Randomizes a spawn position in a radius around the the gold ore.
            //RPV = RadomPositionValue RDP = RandomDropPosition.
            Vector3 RPV = new Vector3(Random.Range(0, rndPosRng),0, Random.Range(0, rndPosRng));
            Vector3 RDP = this.transform.position + RPV;

            //Randomisine the rotation of the instantited object
            Quaternion RRP = new Quaternion(Random.Range(0, rndRotRng), Random.Range(0, rndRotRng), Random.Range(0, rndRotRng), 0);
            Instantiate(goldDrops[0],RDP,RRP);
        }

        Destroy(this.gameObject);
    }
}
