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
    GameObject C;
    bool exist = true;
    void OnMouseDown()
    {
        if (money.znach >= item.woodcost)
        {
            item.lvl++;
            if ((item.lvl == 5) && (exist))
            {
                GameObject.Find("Main Camera").GetComponent<money>().item.stoneD = true;
                exist = false;
                GameObject A = Instantiate(stone_score, new Vector2(45.3f, 356.39f), Quaternion.identity);
                A.transform.SetParent(canvas.transform, false);
                Instantiate(stone, new Vector2(-0.78f, 2.45f), Quaternion.identity);
                GameObject B = Instantiate(stoneup, new Vector2(-1.552f, 1.108f), Quaternion.identity);
                C = gameObject.transform.parent.gameObject;
                B.transform.SetParent(C.transform, false);
            }
            treescrip.ChopForce += 1;
            item.ChopForce += 1;
            money.znach -= item.woodcost;
            item.woodcost = Mathf.RoundToInt(item.woodcost * 1.5f);
            textscr.dozens(money.znach,ref score_txt);
            textscr.dozens(item.woodcost,ref cost_txt);
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
    void Start()
    {
        if (PlayerPrefs.HasKey("ChopForce"))
        {
            item = new Item(PlayerPrefs.GetInt("ChopLvl"), PlayerPrefs.GetInt("Chopwoodcst"), PlayerPrefs.GetInt("ChopForce"));
        }
        else item = new Item(0,10,1);
        //item = new Item(0, 10, 1);
        treescrip.ChopForce = item.ChopForce;
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
    private void OnApplicationFocus(bool focus)
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
    }
}
