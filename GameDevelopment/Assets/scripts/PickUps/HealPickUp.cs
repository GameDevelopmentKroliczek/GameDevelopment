using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    public PlayerMouseController player;

    private void OnTriggerEnter(Collider other)
    {

        PlayerMouseController player = other.GetComponent<PlayerMouseController>();

        if (player != null)

        {
            player.Heal();
            Destroy(this.gameObject);
        }
    }
}
