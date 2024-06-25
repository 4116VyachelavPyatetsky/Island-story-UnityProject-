using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNscr : MonoBehaviour
{
    public GameObject plane;
    public GameObject lazer;
    Vector3 target;
    Animator anm;
    bool isBusy = false;
    bool isShooting = false;
    public AudioSource au;
    void Start()
    {
        plane = GameObject.Find("plane");
        anm = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent.position.y < 3.7f) {
            if (!isBusy) StartCoroutine(LazerShot());
            if (!isShooting)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(plane.transform.position.y - transform.position.y, plane.transform.position.x - transform.position.x) * Mathf.Rad2Deg + 90), 0.03f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(plane.transform.position.y - transform.position.y, plane.transform.position.x - transform.position.x) * Mathf.Rad2Deg + 90);
            }
        }
    }
    IEnumerator LazerShot()
    {
        isBusy = true;
        yield return new WaitForSeconds(4.0f);
        anm.SetTrigger("shot");
        au.Play();
        isShooting = true;
        isBusy = false;
    }
    public void Shot()
    {
        GameObject A = Instantiate(lazer);
        A.GetComponent<LineRenderer>().SetPosition(0, transform.GetChild(0).position - A.transform.position);
        A.GetComponent<LineRenderer>().SetPosition(1, target - A.transform.position);
        anm.SetTrigger("shot");
        isShooting = false;
    }
    public void DefineTarget()
    {
        //target = plane.transform.position +3f*(plane.transform.position- transform.GetChild(0).position);
        target = transform.GetChild(0).position + (transform.GetChild(0).position - transform.position) * 25f;
    }
}
