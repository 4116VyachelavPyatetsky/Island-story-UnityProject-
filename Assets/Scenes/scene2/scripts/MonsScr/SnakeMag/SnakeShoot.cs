using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeShoot : MonoBehaviour
{
    public GameObject proj;
    Vector3 target;
    GameObject plane;
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("plane");
        target = plane.transform.position;
        anm = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void StartAttack()
    {
        if (plane != null)
        {
            target = plane.transform.position;
            anm.SetTrigger("hih");
        }
    }
    void Attack()
    {
        GameObject A = Instantiate(proj, transform.position, Quaternion.identity);
        A.GetComponent<projscript>().rastoynie = target + (target - transform.position) * 10;
        A.GetComponent<projscript>().Vzriv = false;
        A.GetComponent<projscript>().projSpeed = 8f;
        A.GetComponent<Animator>().SetBool("bulltype", true);
        A.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        anm.SetTrigger("hih");
    }

}
