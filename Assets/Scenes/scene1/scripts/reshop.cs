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
    void BUY()
    {
        item.lvl++;
        money.znach -= item.woodcost;
        item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f);
        if (item.lvl == 5)
        {
            stonei = Instantiate(stoneicon, new Vector2(-1.61f, 1.26f), Quaternion.identity);
            stonecost_txt = Instantiate(stone_txt);
            stonei.transform.localScale = new Vector2(0.1f, 0.1f);
            stonei.transform.SetParent(gameObject.transform.parent.gameObject.transform);
            stonecost_txt.transform.SetParent(B, false);
            textscr.dozens(item.stonecost, ref stonecost_txt);
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
        anim.SetInteger("lvl", item.lvl);
    }
    void OnMouseDown()
    {
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
        }
        else
        {
            if (money.znach >= item.woodcost && item.lvl<5)
            {
                BUY();
            }
            else if (money.znach >= item.woodcost && money.stoneznach >= item.stonecost)
            {
                BUY();
            }
        }
    }
    public class Item
    {
        public int lvl;
        public int woodcost;
        public int stonecost;

        public Item(int prz=0, int prs=100, int prd=0)
        {
            lvl = prz;
            woodcost = prs;
            stonecost = prd;
        }
    }
    void Start()
    {
        GameObject Canvas1 = GameObject.Find("Canvas");
        B = Canvas1.transform.Find("Costtetx");
        if (PlayerPrefs.HasKey("ReWwoodcst"))
        {
            item = new Item(PlayerPrefs.GetInt("ReWoodLvl"), PlayerPrefs.GetInt("ReWwoodcst"), PlayerPrefs.GetInt("RewStonecos"));
        }
        else item = new Item(0, 100, 0);
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
            }
            anim.SetInteger("lvl", item.lvl);
            if (item.lvl >= 5)
            {
                stonei = Instantiate(stoneicon, new Vector2(-3.45f, 1.26f), Quaternion.identity);
                stonecost_txt = Instantiate(stone_txt);
                stonei.transform.localScale = new Vector2(0.1f, 0.1f);
                stonei.transform.SetParent(gameObject.transform.parent.gameObject.transform);
                stonecost_txt.transform.SetParent(B, false);
                textscr.dozens(item.stonecost, ref stonecost_txt);
            }
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
    private void OnApplicationFocus(bool focus)
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
    }
}
