using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BuyStoneForce : MonoBehaviour
{
    public class Item
    {
        public int cost;
        public int MineForce;
        public int lvl;

        public Item(int prz=60, int prd=1, int prl=0)
        {
            cost = prz;
            MineForce = prd;
            lvl = prl;
        }
    }
    public Item item;
    public GameObject Text1;
    public GameObject Res;
    GameObject A;
    GameObject Score;
    void Start()
    {
        A = Instantiate(Text1, new Vector2(-1.63f, -2380.0f), Quaternion.identity);
        GameObject Canvas1 = GameObject.Find("Canvas"); 
        Transform B = Canvas1.transform.Find("Costtetx");
        Score = GameObject.Find("stonescore(Clone)");
        A.transform.SetParent(B, false);
        if (PlayerPrefs.HasKey("Minewoodcst"))
        {
            item = new Item(PlayerPrefs.GetInt("Minewoodcst"), PlayerPrefs.GetInt("MineForce"), PlayerPrefs.GetInt("MineLvl"));
        }
        else item = new Item(60, 1, 0);
        //item = new Item(60, 1, 0);
        Stonescr.MineForce = item.MineForce;
        textscr.dozens(item.cost, ref A);
        if (item.lvl >= 5)
        {
            GameObject A = Instantiate(Res, new Vector3(-1.46f, 0.47f, 0.0f), Quaternion.identity);
            GameObject C = gameObject.transform.parent.gameObject;
            A.transform.SetParent(C.transform, false);
        }
    }
    void OnMouseDown()
    {
        if (money.stoneznach >= item.cost)
        {
            item.lvl++;
            if(item.lvl == 5)
            {
                GameObject A = Instantiate(Res,new Vector3(-1.46f, 0.47f, 0.0f), Quaternion.identity);
                GameObject C = gameObject.transform.parent.gameObject;
                A.transform.SetParent(C.transform, false);
            }
            money.stoneznach -= item.cost;
            item.cost = Mathf.RoundToInt(item.cost * 1.5f);
            Stonescr.MineForce += 1;
            item.MineForce += 1;
            textscr.dozens(money.stoneznach, ref Score);
            textscr.dozens(item.cost, ref A);
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
        PlayerPrefs.SetInt("MineLvl", item.lvl);
        PlayerPrefs.SetInt("Minewoodcst", item.cost);
        PlayerPrefs.SetInt("MineForce", item.MineForce);
    }
}
