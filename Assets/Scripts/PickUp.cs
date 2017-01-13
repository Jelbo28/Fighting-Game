using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Bobby");
            //GM.instance.PowerUp(other.GetComponent<PlayerMovement>().playerNumber); Send number to Gm so they know who to give power to.
            Destroy(gameObject);
        }
    }
}
