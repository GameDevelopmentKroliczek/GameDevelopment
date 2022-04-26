using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
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
            
            DestroyShield();
        }
    }





 private void DestroyShield()
    {
        gameObject.SetActive(false);
    }
}
