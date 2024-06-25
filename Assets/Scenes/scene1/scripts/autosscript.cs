using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class autosscript : MonoBehaviour
{
    GameObject Score;
    bool isBusy = false;
    public static float speed = 0.25f;
    public static int reStonePower = 1;
    AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
        Score = GameObject.Find("stonescore(Clone)"); 
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
        au.Play();
        money.stoneznach += reStonePower;
        textscr.dozens(money.stoneznach, ref Score);
        yield return new WaitForSeconds(speed);
        isBusy = false;
    }
}
