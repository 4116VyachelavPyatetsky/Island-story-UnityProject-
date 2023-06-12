using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class treescrip : MonoBehaviour
{
    public static int ChopForce=1;
    public GameObject score_txt;
    Animator antor;
    public GameObject partcle;
    private void Start()
    {
        antor = gameObject.GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        Instantiate(partcle);
        antor.SetTrigger("punch");
        money.znach += ChopForce;
        textscr.dozens(money.znach, ref score_txt);
    }
    void ChangeTriger()
    {
        antor.SetTrigger("punch");
    }
}
