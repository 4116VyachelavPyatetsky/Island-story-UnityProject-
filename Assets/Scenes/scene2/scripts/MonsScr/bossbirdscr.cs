using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbirdscr : MonoBehaviour
{
    public GameObject projectie;
    Transform head;
    EdgeCollider2D coll;
    Animator anim,GlavAnim;
    public GameObject[] atacks;
    float dopspeed = 1.0f;
    string napr = "left";
    bool isBusy = false;
    bool FeatherAttack = false;
    bool Straight = false;
    bool attackReady = false;
    int schetStraughtAttack = 3;
    List<Vector2> edge1 = new List<Vector2>(),edge2;

    enemyhp hpBird;

    public AudioSource au;
    public AudioClip Strafe;
    public AudioClip Spit;
    void Start()
    {
        coll = gameObject.GetComponent<EdgeCollider2D>();
        coll.GetPoints(edge1);
        edge2 = new List<Vector2>() { new Vector2(0, 0.934f), new Vector2(-1.2f, 1.236f), new Vector2(-0.916f, 0.262f), new Vector2(-0.398f, -0.355f), new Vector2(0, -0.97f), new Vector2(0.416f, -0.325f), new Vector2(0.9f, 0.3f), new Vector2(1.17f, 1.29f), new Vector2(0, 0.93f) };
        head = gameObject.transform.Find("heead");
        anim = head.GetComponent<Animator>();
        GlavAnim = gameObject.GetComponent<Animator>();
        hpBird = gameObject.GetComponent<enemyhp>();
    }
    void Update()
    {
        if (!wavescript.gamestopped)
        {
            dopspeed = 1.0f + (hpBird.maxHP - hpBird.hp) / 2.0f / hpBird.maxHP;
            if (gameObject.transform.position.x >= 1.13f)
            {
                napr = "left";
            }
            else if (gameObject.transform.position.x <= -1.13f)
            {
                napr = "right";
            }
            if (napr == "left" && !Straight)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.13f, transform.position.y, 0.0f), 1.4f * Time.deltaTime * dopspeed);
            }
            else if (!Straight)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.13f, transform.position.y, 0.0f), 1.4f * Time.deltaTime * dopspeed);
            }
            if (!isBusy && !Straight)
            {
                StartCoroutine(Wait());
            }
            if (!FeatherAttack)
            {
                StartCoroutine(FeathAtcak(Random.Range(2, 3)));
            }
            if (Straight)
            {
                if (schetStraughtAttack == 0)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, 3.9f, 0.0f), 1.4f * Time.deltaTime * dopspeed);
                    if (transform.position.y < 3.8)
                    {
                        attackReady = false;
                        GlavAnim.SetBool("atack", false);
                        coll.SetPoints(edge1);
                        Straight = false;
                        schetStraughtAttack = Random.Range(1, 4);
                    }
                }
                if (transform.position.y < 6.9f && !attackReady)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, 7f, 0.0f), 1.4f * Time.deltaTime * dopspeed);
                }
                else
                {
                    coll.SetPoints(edge2);
                    attackReady = true;
                    GlavAnim.SetBool("atack", true);
                    StraightAttack();
                }
            }
        }
    }
    IEnumerator Wait()
    {
        if (transform.position.y < 3.88f)
        {
            isBusy = true;
            anim.SetBool("fire", true);
            yield return new WaitForSeconds(0.33f);
            au.PlayOneShot(Spit);
            GameObject A = Instantiate(projectie, gameObject.transform.position, Quaternion.identity);
            projscript B = A.GetComponent<projscript>();
            B.rastoynie = GameObject.Find("plane").transform.position;
            yield return new WaitForSeconds(0.33f);
            anim.SetBool("fire", false);
            yield return new WaitForSeconds(5.33f / dopspeed);
            isBusy = false;
        }
    }
    IEnumerator FeathAtcak(float time)
    {
        FeatherAttack = true;
        GameObject A = Instantiate(atacks[Random.Range(0,atacks.Length)], gameObject.transform.position + new Vector3(0.81f,0,0), Quaternion.identity);
        yield return new WaitForSeconds(time / dopspeed);
        Destroy(A);
        if (Random.Range(0, 6) == 1)
        {
            au.PlayOneShot(Strafe);
            Straight = true;
        }
        FeatherAttack = false;
    }
    void StraightAttack()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, transform.position + Vector3.down, 10f * Time.deltaTime * dopspeed);
        if(transform.position.y < -20.7f)
        {
            au.PlayOneShot(Strafe);
            transform.position = new Vector3(transform.position.x +( Random.Range(0,3) - 1),6.5f,0);
            schetStraughtAttack -= 1;
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
