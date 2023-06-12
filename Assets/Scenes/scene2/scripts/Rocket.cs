using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    void FixedUpdate()
    {
        if (wavescript.gamestopped)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position- transform.up,0.1f);
    }
    private void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player" || lel.gameObject.tag == "DamagedPlayer")
        {
            ShootRocket.amountOfRocket++;
            GameObject.Find("RocketButton").GetComponent<ShootRocket>().UpdtText();
            Destroy(gameObject);
        }
    }
}
