using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectIle : MonoBehaviour
{
    public int dmg = 1;
    float Projspeed = 6f;
    public Vector3 target;
    Animator anim;
    Vector3 rastoynie;
    void Start()
    {

        float angle = transform.eulerAngles.z * Mathf.PI / 180.0f;
        target = new Vector3(Mathf.Sin(angle), -Mathf.Cos(angle),0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, transform.position + target, Projspeed*Time.deltaTime);
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
            Destroy(gameObject);
        }
    }
}
