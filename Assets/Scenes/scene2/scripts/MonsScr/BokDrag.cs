using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokDrag : MonoBehaviour
{
    public GameObject bull;
    public GameObject mainbody;
    Vector3 target;
    GameObject plane;
    int schet = 2;
    bool showstop = false;
    bool stophide = true;
    public bool onscene = false;
    WaveContoller wave;
    Animator anm;

    AudioSource au;
    private void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        plane = GameObject.Find("plane");
        target = plane.transform.position;
        anm = gameObject.GetComponent<Animator>();
        wave = transform.parent.gameObject.transform.parent.gameObject.GetComponent<WaveContoller>();
        //NewPos();
    }
    private void FixedUpdate()
    {
        if (onscene && !wavescript.gamestopped)
        {
            if (!showstop) Show();
            if (!stophide) Hide();
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(plane.transform.position.y - transform.position.y, plane.transform.position.x - transform.position.x) * Mathf.Rad2Deg + 90);
        }
    }
    void FindTarget()
    {
        au.Play();
        if (!wavescript.gamestopped)
        {
            target = plane.transform.position;
        }
    }
    void Shoot()
    {
        GameObject A =Instantiate(bull, transform.position, Quaternion.identity);
        A.GetComponent<projscript>().rastoynie = target + (target - transform.position) * 10;
        A.GetComponent<projscript>().Vzriv = false;
        A.GetComponent<projscript>().projSpeed = 8f;
        A.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        schet--;
        if (schet <= 0)
        {
            anm.SetTrigger("trg");
            stophide = false;
        }
    }
    void Show()
    {
        if (mainbody.transform.position.x < 0)
        {
            mainbody.transform.position = Vector3.MoveTowards(mainbody.transform.position, mainbody.transform.position+new Vector3(1,0,0),0.03f);
            if (mainbody.transform.position.x > -2.8f)
            {
                showstop = true;
                anm.SetTrigger("trg");
            }
        }
        else
        {
            mainbody.transform.position = Vector3.MoveTowards(mainbody.transform.position, mainbody.transform.position - new Vector3(1, 0, 0), 0.03f);
            if (mainbody.transform.position.x < 2.89f)
            {
                showstop = true;
                anm.SetTrigger("trg");
            }
        }
    }
    void Hide()
    {
        if (mainbody.transform.position.x < 0)
        {
            mainbody.transform.position = Vector3.MoveTowards(mainbody.transform.position, mainbody.transform.position - new Vector3(1, 0, 0), 0.03f);
            if (mainbody.transform.position.x < -4.37f)
            {
                stophide = true;
                NewPos();
            }
        }
        else
        {
            mainbody.transform.position = Vector3.MoveTowards(mainbody.transform.position, mainbody.transform.position + new Vector3(1, 0, 0), 0.03f);
            if (mainbody.transform.position.x > 4.37f) 
            { 
                stophide = true;
                NewPos();
            }
        }
    }
    public void NewPos()
    {
        if (mainbody != null) {
            showstop = false;
            schet = 2;
            if (Random.Range(0, 2) == 0)
            {
                mainbody.transform.position = new Vector3(mainbody.transform.position.x * -1, 0, 0);
                mainbody.transform.eulerAngles = new Vector3(0, 0, mainbody.transform.eulerAngles.z * -1);
            }
            else
            {
                mainbody.transform.position = new Vector3(mainbody.transform.position.x, 0, 0);
            }

            mainbody.transform.position = new Vector3(mainbody.transform.position.x, wave.PosProve(mainbody), 0);
        }
    }
}
