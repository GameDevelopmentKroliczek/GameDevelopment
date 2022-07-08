using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldOverlay;
    public float ShieldTimer = 5f;

    public void OnEnable()
    {
        StartCoroutine(ShieldTime());
        ShieldOverlay.gameObject.SetActive(true);
    }

    //Schild wird zerst�rt wenn er getroffen wird, Spieler bekommt keinen Schaden

    private void OnTriggerEnter(Collider other)
    {
        //Spiel wird gestoppt bei Kollision mit Asteroid
        asteroidController asteroid = other.GetComponent<asteroidController>();
        EnemyBullet bullet = other.GetComponent<EnemyBullet>();
        //collision.gameObject.tag == "Spawnable";
        if (asteroid != null || bullet != null)
        {
            Destroy(other.gameObject);
            ShieldOverlay.gameObject.SetActive(false);
            DestroyShield();
        }
    }

    IEnumerator ShieldTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShieldTimer);
            DestroyShield();
        }
    }




 private void DestroyShield()
    {
        gameObject.SetActive(false);
    }
}
