using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stonescr : MonoBehaviour
{
    public static int MineForce = 1;
    GameObject score_txt;
    public GameObject partcle;
    AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
        score_txt = GameObject.Find("stonescore(Clone)") ;
        woodscoreY A = GameObject.Find("woodscore").GetComponent<woodscoreY>();
        A.stonescore = transform.GetChild(0).gameObject;
        A.Kamen();
    }
    void OnMouseDown()
    {
        au.pitch = Random.Range(0.8f, 1.2f);
        au.Play();
        Instantiate(partcle, Camera.main.ScreenToWorldPoint(Input.mousePosition) +new Vector3(0,0,10),Quaternion.identity);
        money.stoneznach += MineForce;
        textscr.dozens(money.stoneznach, ref score_txt);
    }
}
