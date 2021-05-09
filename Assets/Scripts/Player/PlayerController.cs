using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int health, maxHealth;
    public int playerScore;

    [Header("Player States")]
    public bool isPlayerDead;


<<<<<<< Updated upstream
    public void AddHealth(int healAmount)
    {
        if (health >= maxHealth || isPlayerDead)
            return;
        else
        {
            health = health + healAmount;
        }
=======
    [Header("Audio")]
    public AudioSource playerAudio;
    public AudioClip shroomBite;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            gun.TriggerDown();
        if (Input.GetKeyDown(KeyCode.R))
            gun.Reload();
        if (Input.GetKeyDown(KeyCode.G))
            SpawnDynamite();
        if (Input.GetKeyDown(KeyCode.E))
            ConsumeShroom();
    }
    public void PickupShroom()
    {
        if (shroomCount >= maxShroomCount)
            return;

        shroomCount++;
    }

    void SpawnDynamite()
    {
        GameObject dynamite = Instantiate(prefabDynamite, spawnPos.position, spawnPos.rotation);
        dynamite.GetComponent<Rigidbody>().AddForce(dynamite.transform.forward * projectileForce);
    }

    public void ConsumeShroom()
    {
        if (health >= maxHealth || isPlayerDead)
            return;
        if (shroomCount <= 0)
            return;

        PlayAudio(shroomBite);
        shroomCount--;
        health++;
>>>>>>> Stashed changes
    }

    public void PlayAudio(AudioClip audio)
    {
        playerAudio.PlayOneShot(audio);
    }

    public void AddScore(int score)
    {
        playerScore = playerScore + score;
        Debug.Log("Player Score = " + playerScore);
    }

    public void TakeDamge()
    {
        if (isPlayerDead)
            return;

        health--;
    }

    public void Die()
    {
        Debug.Log("You Died");
    }
}
