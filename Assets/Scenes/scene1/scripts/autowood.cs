using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class autowood : MonoBehaviour
{
    GameObject score_txt;
    bool isBusy = false;
    public static float speed = 0.25f;
    public static int rewoodPower = 1;

    bool newClip = false;
    AudioSource au;
    public AudioClip clipTwo;

    private void Awake()
    {
        au = GetComponent<AudioSource>();
    }
    void Start()
    {
        score_txt = GameObject.Find("Text"); ;
    }
    private void Update()
    {
        if (!isBusy)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isBusy = true;
        yield return new WaitForSeconds(speed);
        //if(!newClip) au.Play();
        money.znach += rewoodPower;
        textscr.dozens(money.znach, ref score_txt);
        yield return new WaitForSeconds(speed);
        isBusy = false;
    }
    public void chageSound()
    {
        Debug.Log("lol");
        newClip = true;
        au.loop = true;
        au.PlayOneShot(clipTwo);
    }
}
