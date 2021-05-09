using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    [Header("Components")]
    public GameObject[] prefabs;
    public GameObject[] walls;
    public GameObject[] nodes;

    private void Start()
    {
        Varient();
    }
    void Varient()
    {
        bool isNF = Random.Range(0, 2) > 0;
        bool isEF = Random.Range(0, 2) > 0;
        bool isSF = Random.Range(0, 2) > 0;
        bool isWF = Random.Range(0, 2) > 0;

        //Set Wall status.
        walls[0].SetActive(isNF);
        walls[1].SetActive(isEF);
        walls[2].SetActive(isSF);
        walls[3].SetActive(isWF);

        //Set nodes status.
        nodes[0].SetActive(isNF);
        nodes[1].SetActive(isEF);
        nodes[2].SetActive(isSF);
        nodes[3].SetActive(isWF);

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i])
                SpawnNext(nodes[i].transform);
        }
    }
    
    void SpawnNext(Transform node)
    {
        Instantiate(prefabs[0], node);
    }
}
