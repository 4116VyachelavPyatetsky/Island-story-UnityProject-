using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class projscript : MonoBehaviour
{
    Animator anim;
    public Vector3 pos,rastoynie;
    bool dead = false;
    public float projSpeed = 5f;
    public bool Vzriv = true;
    GameObject player;
    public GameObject proj;
    void Start()
    {
        player = GameObject.Find("plane");
        anim = gameObject.GetComponent<Animator>();
        //rastoynie = player.transform.position;
    }
    void Update()
    {
        if (wavescript.gamestopped)
        {
            Destroy(gameObject);
        }
        if (!dead)
        {
            //transform.Translate(rastoynie*Time.deltaTime/100f);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rastoynie, projSpeed * Time.deltaTime);
        }
        
        if((transform.position - rastoynie).magnitude < 0.1f && Vzriv)
        {
            for(int i = 0; i < 6; i++)
            {
                GameObject A = Instantiate(proj,transform.position, Quaternion.identity);
                A.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                projscript B = A.GetComponent<projscript>();
                B.Vzriv = false;
                B.rastoynie = new Vector3(Mathf.Cos(45*i), Mathf.Sin(45 * i), 0)* 20f + transform.position;
            }
            Smert();
            Vzriv = false;
        }
        objectoutofarena.outofarena(gameObject);
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "ShieldUpgr")
        {
            Destroy(gameObject);
        }
        else if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
            Smert();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.16f);
        Destroy(gameObject);
    }
    void Smert()
    {
        dead = true;
        anim.SetBool("dead", true);
        StartCoroutine(Wait());
    }
}
