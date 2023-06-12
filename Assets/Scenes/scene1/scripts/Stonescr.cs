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
    void Start()
    {
        score_txt = GameObject.Find("stonescore(Clone)") ;
    }
    void OnMouseDown()
    {
        Instantiate(partcle, Camera.main.ScreenToWorldPoint(Input.mousePosition) +new Vector3(0,0,10),Quaternion.identity);
        money.stoneznach += MineForce;
        textscr.dozens(money.stoneznach, ref score_txt);
    }
}
