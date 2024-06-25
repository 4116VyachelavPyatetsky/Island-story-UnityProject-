using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitMons90 : MonoBehaviour
{
    Vector3 napr;
    float monsspeed = 0.06f;
    public float obzor = 0.2f;
    private float Rota;
    bool found = false;
    GameObject plane;
    Animator anim;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        napr = new Vector3(transform.position.x, transform.position.y - 100.0f, 0);
        plane = GameObject.Find("plane");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!wavescript.gamestopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, napr, monsspeed);
        }
        if (transform.position.y < -6.0f | transform.position.x < -3.44f | transform.position.x > 3.44f)
        {
            Destroy(gameObject.GetComponent<enemyhp>().health);
            Destroy(gameObject);
        }
        if (transform.position.y + obzor > plane.transform.position.y && transform.position.y - obzor < plane.transform.position.y && !found && plane != null)
        {
            au.pitch = Random.Range(0.9f, 1.1f);
            au.Play();
            if (transform.position.x < plane.transform.position.x) Rota = 90;
            else Rota = -90;
            napr = new Vector3(transform.position.x + 100.0f * Mathf.Sin(Rota), transform.position.y, 0);
            found = true;
            anim.Play("speedupStraight", 0, 0);
            monsspeed *= 2;
        }
        if (found) 
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Rota), 0.12f);
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
}
