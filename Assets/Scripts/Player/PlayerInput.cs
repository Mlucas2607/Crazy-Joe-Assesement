using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Shotgun gun;

    [Header("Dynamite")]
    public Transform spawnPos;
    public GameObject prefabDynamite;
    public float projectileForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            gun.TriggerDown();
        if (Input.GetKeyDown(KeyCode.R))
            gun.Reload();
        if (Input.GetKeyDown(KeyCode.G))
            SpawnDynamite();
    }

    void SpawnDynamite()
    {
        GameObject dynamite = Instantiate(prefabDynamite, spawnPos.position, spawnPos.rotation);
        dynamite.GetComponent<Rigidbody>().AddForce(dynamite.transform.forward * projectileForce);
    }
}

