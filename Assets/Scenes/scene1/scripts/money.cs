using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class money : MonoBehaviour
{
    public Item item;
    public GameObject temn;
    public static int znach;
    public static int stoneznach;
    public GameObject butt, bt1, bt2;
    public GameObject score;
    public GameObject stonescore;
    public GameObject stone;
    public GameObject canvas;
    public GameObject stoneup;
    public GameObject shop;
    public GameObject AddWindow;
    public GameObject UnAddWindow;
    public GameObject ChopForce;
    public static int DontHaveMoney = 0;

    public GameObject shop_button;

    public static bool stoped = false;
    public GameObject Menu,menu_temn,tree,stn;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("znachD"))
        {
            if (PlayerPrefs.GetInt("stoneD") == 0)
            {
                item = new Item(PlayerPrefs.GetInt("znachD"), PlayerPrefs.GetInt("stoneznachD"), false);
            }
            else
            {
                item = new Item(PlayerPrefs.GetInt("znachD"), PlayerPrefs.GetInt("stoneznachD"), true);
            }
        }
        else item = new Item(0, 0, false);
    }
    public void LoadField()
    {
        stonescore.SetActive(false);
        //item = new Item(0, 0, false);
        znach = item.znachD;
        stoneznach = item.stoneznachD;
        if (item.stoneD)
        {
            Instantiate(stone, new Vector2(-0.78f, 2.42f), Quaternion.identity);
            stonescore.SetActive(true);
            stonescore.GetComponent<Text>().text = stoneznach.ToString();
            GameObject B = Instantiate(stoneup, new Vector2(-1.552f, 1.108f), Quaternion.identity);
            B.transform.SetParent(shop.transform, false);
            textscr.dozens(stoneznach, ref stonescore);
        }
        textscr.dozens(znach, ref score);
        //znach = 10000;

    }
    public void SaveField()
    {
        //item.znachD = znach;
        //item.stoneznachD = stoneznach;
        PlayerPrefs.SetInt("znachD", znach);
        PlayerPrefs.SetInt("stoneznachD", stoneznach);
        if (item.stoneD) PlayerPrefs.SetInt("stoneD",1);
        else PlayerPrefs.SetInt("stoneD",0);
        //PlayerPrefs.DeleteAll();
    }
    bool IsExist()
    {
        GameObject go =GameObject.Find("stonescore(Clone)");
        if (go == null)
        {
            return (false);
        }
        else return (true);
    }
    public class Item
    {
        public int znachD;
        public int stoneznachD;
        public bool stoneD;

        public Item(int prz, int prs,bool prd)
        {
            znachD = prz;
            stoneznachD = prs;
            stoneD = prd;
        }
    }
    void Start()
    {
        StopTheGame();
        StopTheGame();
        TurnOn(PlayerPrefs.GetInt("ReMineLvl")>0);
        LoadField();
        stn = GameObject.Find("stonic 1(Clone)");
    }
    void OnApplicationQuit()
    {
        SaveField();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("sce2");
        }
    }
    private void OnDisable()
    {
        SaveField();
    }
    private void OnApplicationPause(bool focus)
    {
        if (!focus)
        {
            SaveField();
        }
    }
    public void TurnOn(bool turner)
    {
        bt1.SetActive(turner);
        bt2.SetActive(turner);
        butt.SetActive(turner);
    }

    public void StopTheGame()
    {
        if (!stoped)
        {
            Time.timeScale = 0;
            stoped = true;
        }
        else
        {
            Time.timeScale = 1;
            stoped = false;
        }
        if (stn != null) stn.GetComponent<BoxCollider2D>().enabled = !stoped;
        tree.GetComponent<BoxCollider2D>().enabled = !stoped;
        shop_button.GetComponent<BoxCollider2D>().enabled = !stoped;
        Menu.SetActive(stoped);
        menu_temn.SetActive(stoped);
    }
    public void Addvertise()
    {
        if (RewardedAds.Ad_is_ready)
        {
            if (!stoped)
            {
                if (TimerToGO.IsWorking)
                {
                    UnAddWindow.SetActive(true);
                }
                else
                {
                    AddWindow.SetActive(true);
                    if (ChopForce.GetComponent<WoodChopForce>().item.lvl < 5)
                    {
                        AddWindow.transform.GetChild(4).gameObject.SetActive(false);
                        AddWindow.transform.GetChild(6).gameObject.SetActive(false);
                    }
                    else
                    {
                        AddWindow.transform.GetChild(4).gameObject.SetActive(true);
                        AddWindow.transform.GetChild(6).gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    private void OnDestroy()
    {
        SaveField();
    }
    public void Exit()
    {
        SaveField();
        Application.Quit();
    }
}
