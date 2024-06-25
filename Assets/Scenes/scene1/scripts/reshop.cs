using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class reshop : MonoBehaviour
{
    public Item item;
    public GameObject score_txt;
    public GameObject cost_txt;
    public GameObject stoneicon;
    public GameObject stone_txt;
    public GameObject Level;
    GameObject wodch;
    GameObject stoescore_txt;
    GameObject stonei;
    GameObject stonecost_txt;
    Transform B;
    public GameObject AutoWoodChuck;
    Animator anim;
    bool exist = false;
    bool stonic = false;
    float j=1.0f;

    AudioSource au;

    public class Item
    {
        public int lvl;
        public int woodcost;
        public int stonecost;

        public Item(int prz = 0, int prs = 100, int prd = 100)
        {
            lvl = prz;
            woodcost = prs;
            stonecost = prd;
        }
    }
    void BUY()
    {
        item.lvl++;
        Level.GetComponent<Text>().text = item.lvl.ToString();
        money.znach -= item.woodcost;
        item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f);
        if (item.lvl == 5)
        {
            stonei = Instantiate(stoneicon, new Vector2(-0.28f, 1.37f), Quaternion.identity);
            stonecost_txt = Instantiate(stone_txt);
            stonei.transform.localScale = new Vector2(0.2f, 0.2f);
            stonei.transform.SetParent(gameObject.transform.parent.gameObject.transform);
            stonecost_txt.transform.SetParent(B, false);
            textscr.dozens(item.stonecost, ref stonecost_txt);
            j += 0.25f;
            autowood.speed -= 0.05f;
            anim.SetFloat("speed", j);
        }
        if (item.lvl < 5)
        {
            j += 0.25f;
            autowood.speed -= 0.05f;
            anim.SetFloat("speed", j);
        }
        if (item.lvl > 5)
        {
            money.stoneznach -= item.stonecost;
            item.stonecost = Mathf.RoundToInt(item.stonecost * 1.5f);
            textscr.dozens(item.stonecost, ref stonecost_txt);
            if (!stonic)
            {
                stonic = true;
                stoescore_txt = GameObject.Find("stonescore(Clone)");
            }
            textscr.dozens(money.stoneznach, ref stoescore_txt);
            autowood.rewoodPower += 1;
        }
        textscr.dozens(money.znach, ref score_txt);
        textscr.dozens(item.woodcost, ref cost_txt);
        if(item.lvl == 6)
        {
            //wodch.GetComponent<autowood>().chageSound();
        }
        anim.SetInteger("lvl", item.lvl);
    }
    void OnMouseDown()
    {
        au.Play();
        gameObject.GetComponent<Animation>().Play("ShopKnopAnm");
        if ((money.znach >= item.woodcost) && (exist == false))
        {
            wodch = Instantiate(AutoWoodChuck, new Vector2(0.05f, -0.5f), Quaternion.identity);
            anim = wodch.GetComponent<Animator>();
            money.znach -= item.woodcost;
            item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f); 
            textscr.dozens(money.znach, ref score_txt);
            textscr.dozens(item.woodcost, ref cost_txt);
            exist = true;
            item.lvl++;
            Level.GetComponent<Text>().text = item.lvl.ToString();
        }
        else
        {
            if(money.znach >= item.woodcost)
            {
                if (item.lvl < 5)
                {
                    BUY();
                }
                else if(money.stoneznach >= item.stonecost)
                {
                    BUY();
                }
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
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey("ReWwoodcst"))
        {
            item = new Item(PlayerPrefs.GetInt("ReWoodLvl"), PlayerPrefs.GetInt("ReWwoodcst"), PlayerPrefs.GetInt("RewStonecos"));
        }
        else item = new Item(0, 100, 100);
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
        GameObject Canvas1 = GameObject.Find("CanvasShop");
        B = Canvas1.transform.Find("Costtetx");
        //item = new Item(0, 100, 0);
        j += (item.lvl-1)*0.25f;
        if (item.lvl != 0)
        {
            wodch = Instantiate(AutoWoodChuck, new Vector2(0.05f, -0.5f), Quaternion.identity);
            anim = wodch.GetComponent<Animator>();
            textscr.dozens(item.woodcost, ref cost_txt);
            exist = true;
            if (item.lvl < 5)
            {
                autowood.speed -= (0.05f * (item.lvl - 1));
                anim.SetFloat("speed", j);
            }
            else
            {
                autowood.rewoodPower = 1 + item.lvl - 4;
                //wodch.GetComponent<autowood>().chageSound();
            }
            anim.SetInteger("lvl", item.lvl);
            if (item.lvl >= 5)
            {
                stonei = Instantiate(stoneicon, new Vector2(-0.28f, 1.37f), Quaternion.identity);
                stonecost_txt = Instantiate(stone_txt);
                stonei.transform.localScale = new Vector2(0.2f, 0.2f);
                stonei.transform.SetParent(gameObject.transform.parent.gameObject.transform);
                stonecost_txt.transform.SetParent(B, false);
                textscr.dozens(item.stonecost, ref stonecost_txt);
            }
        }
        Level.GetComponent<Text>().text = item.lvl.ToString();
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
        PlayerPrefs.SetInt("ReWoodLvl", item.lvl);
        PlayerPrefs.SetInt("ReWwoodcst", item.woodcost);
        PlayerPrefs.SetInt("RewStonecos", item.stonecost);
        //PlayerPrefs.DeleteAll();
    }
    private void OnDestroy()
    {
        Save();
    }
}
