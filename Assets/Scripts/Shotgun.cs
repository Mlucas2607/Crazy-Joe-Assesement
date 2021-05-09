using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [Header("Raycasting")]
    public Transform shootPos;
    public Transform muzzlePos;

    public GameObject[] weaponEffects;

    [Header("Ammo")]
    public int ammo, maxAmmo;
    public int curClip, maxClip;

    [Header("Weapon Stats")]
    public int DMG = 1;
    public int pelletCount = 10;
    public float pelletSpread = 0.1f;

    [Header("Reloading")]
    public float reloadTime = 1.5f;
    public bool isRelaoding;

    public void TriggerDown()
    {
        if (isRelaoding && curClip > 0)
        {
            isRelaoding = false;
            StopCoroutine(ReloadSequence());
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && curClip > 0)
        {
            curClip--;
            Shoot();
        }
        else
            Reload();
    }

    public void Reload()
    {
        if (isRelaoding || ammo == 0 || curClip == maxClip)
            return;

        StartCoroutine(ReloadSequence());

    }

    void Shoot()
    {
        Instantiate(weaponEffects[0], muzzlePos.position, muzzlePos.rotation);

        Ray gunRay = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit;

        for (int i = 0; i < pelletCount; i++)
        {
            gunRay.direction = shootPos.forward + new Vector3(Random.Range(-pelletSpread, pelletSpread), Random.Range(-pelletSpread, pelletSpread), Random.Range(-pelletSpread, pelletSpread));

            if (Physics.Raycast(gunRay, out hit, 100))
            {
                if (hit.collider.tag == "Enemy")
                    hit.collider.GetComponent<Enemy>().TakeDamage(DMG);

                Instantiate(weaponEffects[1], hit.point, Quaternion.identity);
            }

        }
    }

    private IEnumerator ReloadSequence()
    {
        isRelaoding = true;

        for (int i = curClip; i < maxClip; i++)
        {
            yield return new WaitForSeconds(reloadTime);
            curClip++;
        }

        isRelaoding = false;
    }
}
