using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootRocket : MonoBehaviour
{
    public static int amountOfRocket = 2;
    GameObject plane;
    public GameObject Anm;
    public GameObject ammountText;
    Animator reload;
    bool isPlaying = false;
    public GameObject rocket;
    AudioSource au;


    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        reload = Anm.GetComponent<Animator>();
        plane = GameObject.Find("plane");
        ammountText.GetComponent<Text>().text = amountOfRocket.ToString();
    }

    public void Shoot()
    {
        if (amountOfRocket != 0 && !isPlaying)
        {
            reload.SetTrigger("Enter");
            isPlaying = true;
            amountOfRocket--;
            UpdtText();
            Instantiate(rocket, plane.transform.position, Quaternion.identity);
        }
    }

    public void UpdtText()
    {
        ammountText.GetComponent<Text>().text = amountOfRocket.ToString();
    }
    public void GetRock()
    {
        UpdtText();
        au.Play();
    }
    public void Untrigger()
    {
        isPlaying = false;
    }
    public void Upgr()
    {
        reload.speed = 0.25f;
    }
}