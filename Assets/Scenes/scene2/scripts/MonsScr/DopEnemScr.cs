using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopEnemScr : MonoBehaviour
{
    public Transform trgt;

    private void Start()
    {
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
        gameObject.GetComponent<AudioSource>().PlayDelayed(Random.Range(0.01f, 0.3f));
    }
    void FixedUpdate()
    {
        if (transform.position.y > trgt.position.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(trgt.position.y - transform.position.y, trgt.position.x - transform.position.x) * Mathf.Rad2Deg + 90), 0.06f);
        }
        else if (transform.position.y < -6.12f * wavescript.screenSizePere) Destroy(gameObject);
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, 0.09f);
    }
    private void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
            gameObject.GetComponent<enemyhp>().enemIsDamaged(1);
        }
    }
}
