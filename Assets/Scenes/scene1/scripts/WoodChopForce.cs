using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class WoodChopForce : MonoBehaviour
{
    public Item item;
    public GameObject reshop;
    public GameObject score_txt;
    public GameObject cost_txt;
    public GameObject stone;
    public GameObject canvas;
    public GameObject stoneup;
    public GameObject stone_score;
    public GameObject Level;
    GameObject C;
    bool exist = true;

    AudioSource au;
    void OnMouseDown()
    {
        au.Play();
        gameObject.GetComponent<Animation>().Play("ShopKnopAnm");
        if (money.znach >= item.woodcost)
        {
            item.lvl++;
            Level.GetComponent<Text>().text = item.lvl.ToString();
            if ((item.lvl == 5) && (exist))
            {
                GameObject.Find("Main Camera").GetComponent<money>().item.stoneD = true;
                exist = false;
                stone_score.SetActive(true);
                Instantiate(stone, new Vector2(-0.78f, 2.42f), Quaternion.identity);
                GameObject B = Instantiate(stoneup, new Vector2(-1.552f, 1.108f), Quaternion.identity);
                C = gameObject.transform.parent.gameObject;
                B.transform.SetParent(C.transform, false);
            }
            treescrip.ChopForce += 1;
            item.ChopForce += 1;
            money.znach -= item.woodcost;
            item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f);
            textscr.dozens(money.znach, ref score_txt);
            textscr.dozens(item.woodcost, ref cost_txt);
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
    public class Item
    {
        public int lvl;
        public int woodcost;
        public int ChopForce;

        public Item(int prz=0, int prs=10, int prd=1)
        {
            lvl = prz;
            woodcost = prs;
            ChopForce = prd;
        }
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey("ChopForce"))
        {
            item = new Item(PlayerPrefs.GetInt("ChopLvl"), PlayerPrefs.GetInt("Chopwoodcst"), PlayerPrefs.GetInt("ChopForce"));
        }
        else item = new Item(0, 10, 1);
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
        //item = new Item(0, 10, 1);
        treescrip.ChopForce = item.ChopForce;
        Level.GetComponent<Text>().text = item.lvl.ToString();
        textscr.dozens(item.woodcost, ref cost_txt);
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
        PlayerPrefs.SetInt("ChopLvl", item.lvl);
        PlayerPrefs.SetInt("Chopwoodcst", item.woodcost);
        PlayerPrefs.SetInt("ChopForce", item.ChopForce);
        //PlayerPrefs.DeleteAll();
    }
    private void OnDestroy()
    {
        Save();
    }
}
