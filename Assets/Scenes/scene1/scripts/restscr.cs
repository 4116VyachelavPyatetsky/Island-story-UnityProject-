using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class restscr : MonoBehaviour
{
    public GameObject wCost;
    GameObject Level;
    public GameObject sCost;
    public GameObject wost;
    GameObject MoneyStone;
    GameObject MoneyWood;
    GameObject A;
    GameObject C;
    Transform B;
    Animator anim;
    GameObject M; 
    public Item item;
    float j = 1;

    AudioSource au;
    public class Item
    {
        public int lvl;
        public int woodcost;
        public int stonecost;
        public int MineForce;

        public Item(int prz=0, int prs=100, int prd=100,int lel=1)
        {
            lvl = prz;
            woodcost = prs;
            stonecost = prd;
            MineForce = lel;
        }
    }
    void OnMouseDown()
    {
        au.Play();
        gameObject.GetComponent<Animation>().Play("ShopKnopAnm");
        if (item.stonecost <= money.stoneznach && item.woodcost <= money.znach) 
        {
            item.lvl++;
            Level.GetComponent<Text>().text = item.lvl.ToString();
            item.MineForce++;
            if (item.lvl == 1)
            {
                GameObject.Find("Main Camera").GetComponent<money>().TurnOn(true);
                M = Instantiate(wost);
                anim = M.GetComponent<Animator>();
                //A = Instantiate(wCost);
                //C = Instantiate(sCost);
                GameObject Canvas1 = GameObject.Find("CanvasShop");
                Transform B = Canvas1.transform.Find("Costtetx");
                A.transform.SetParent(B, false);
                C.transform.SetParent(B, false);
            }
            money.znach -= item.woodcost;
            money.stoneznach -= item.stonecost;
            item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f);
            item.stonecost = Mathf.RoundToInt(item.stonecost * 1.5f);
            textscr.dozens(item.woodcost, ref A);
            textscr.dozens(item.stonecost, ref C);
            textscr.dozens(money.znach, ref MoneyWood);
            textscr.dozens(money.stoneznach, ref MoneyStone);
            j += 0.25f;
            anim.SetFloat("speed", j);
        }
        else
        {
            money.DontHaveMoney++;
            if (money.DontHaveMoney >= 2 && !TimerToGO.IsWorking)
            {
                money.DontHaveMoney = 0;
                GameObject.Find("Main Camera").GetComponent<money>().Addvertise();
            }
        }
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
        MoneyStone = GameObject.Find("stonescore(Clone)");
        MoneyWood = GameObject.Find("Text");
        if (PlayerPrefs.HasKey("ReMineWC"))
        {
            item = new Item(PlayerPrefs.GetInt("ReMineLvl"), PlayerPrefs.GetInt("ReMineWC"), PlayerPrefs.GetInt("ReMineSC"), PlayerPrefs.GetInt("ReMineMF"));
        }
        else item = new Item(0, 100, 100,0);
        A = Instantiate(wCost);
        Level = A.transform.GetChild(1).gameObject;
        Level.GetComponent<Text>().text = item.lvl.ToString();
        C = Instantiate(sCost);
        GameObject Canvas1 = GameObject.Find("CanvasShop");
        B = Canvas1.transform.Find("Costtetx");
        A.transform.SetParent(B, false);
        C.transform.SetParent(B, false);
        textscr.dozens(item.woodcost, ref A);
        textscr.dozens(item.stonecost, ref C);
        if (item.lvl > 0)
        {
            M = Instantiate(wost);
            anim = M.GetComponent<Animator>();
            autosscript.reStonePower = item.MineForce;
            autosscript.speed -= (item.lvl-1) * 0.05f;
            j = 1 + ((item.lvl - 1) * 0.25f);
            anim.SetFloat("speed",j);
        }
    }
    void OnApplicationQuit()
    {
        Save();
    }
    private void OnDisable()
    {
        Save();
    }
    private void OnApplicationPause(bool focus)
    {
        if (!focus)
        {
            Save();
        }
    }
    void Save()
    {
        PlayerPrefs.SetInt("ReMineLvl", item.lvl);
        PlayerPrefs.SetInt("ReMineWC", item.woodcost);
        PlayerPrefs.SetInt("ReMineSC", item.stonecost);
        PlayerPrefs.SetInt("ReMineMF", item.MineForce);
        //PlayerPrefs.DeleteAll();
    }
    private void OnDestroy()
    {
        Save();
    }
}
