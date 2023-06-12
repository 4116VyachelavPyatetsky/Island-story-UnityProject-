using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishscr : MonoBehaviour
{
    enemyhp health;
    Animator anim;
    void Start()
    {
        health = gameObject.GetComponent<enemyhp>();
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(Wait());
    }
    void Update()
    {
        if (!wavescript.gamestopped)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, -5.6f, 0.0f), 4f * Time.deltaTime);
        }
        if (gameObject.transform.position.y <= -5.5f)
        {
            Destroy(gameObject.GetComponent<enemyhp>().health);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 1.3f));
        anim.SetBool("entering", true);
    }
}
