using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitMons : MonoBehaviour
{
    Vector3 napr;
    float monsspeed = 0.06f;
    public float obzor = 1.0f;
    bool found = false;
    GameObject plane;
    Animator anim;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        napr = new Vector3(transform.position.x, transform.position.y - 100.0f,0);
        plane = GameObject.Find("plane");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!wavescript.gamestopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, napr, monsspeed);
        }
        if(transform.position.y < -6.0f * wavescript.screenSizePere)
        {
            Destroy(gameObject.GetComponent<enemyhp>().health);
            Destroy(gameObject);
        }
        if (transform.position.x + obzor > plane.transform.position.x && transform.position.x - obzor < plane.transform.position.x && !found && Mathf.Abs(transform.position.y - plane.transform.position.y)<6f)
        {
            found = true;
            au.pitch = Random.Range(0.9f, 1.1f);
            au.Play();
            anim.Play("speedupStraight", 0, 0);
            monsspeed *= 3;
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
