using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShButton : MonoBehaviour
{
    public GameObject add;
    public GameObject cost_txt;
    bool buut=false;
    float ScreenSizePeremen;
    Vector3 EndPos;
    Vector3 SpritePos= new Vector3(-2f, -2.11f, 0.0f);
    bool doSomeThing = false;
    AudioSource au;
    private void Start()
    {
        au = GetComponent<AudioSource>();
        ScreenSizePeremen = Screen.width / 480f;
        buut = true;
        EndPos = new Vector3(cost_txt.transform.position.x - 300.0f * ScreenSizePeremen, cost_txt.transform.position.y, 0.0f);
        cost_txt.transform.position = EndPos;
        transform.parent.gameObject.transform.position = new Vector3(-2f, -2.1f, 0.0f);
    }
    private void FixedUpdate()
    {
        Viezd();
    }
    void OnMouseDown()
    {
        au.Play();
        buut = !buut;
        gameObject.GetComponent<Animation>().Play("KnopAnim");
        if (!buut)
        {
            EndPos = new Vector3(cost_txt.transform.position.x + 300.0f * ScreenSizePeremen, cost_txt.transform.position.y, 0.0f);
            SpritePos = new Vector3(1.7f, -2.11f, 0.0f);
        }
        else
        {
            EndPos = new Vector3(cost_txt.transform.position.x - 300.0f * ScreenSizePeremen, cost_txt.transform.position.y, 0.0f);
            SpritePos = new Vector3(-2f, -2.11f, 0.0f);
        }
        Viezd();
        //Does();
    }
    private void Viezd()
    {
        transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.parent.position, SpritePos, 0.3f);
        cost_txt.transform.position = Vector3.MoveTowards(cost_txt.transform.position,EndPos,25f* ScreenSizePeremen);
    }
}
