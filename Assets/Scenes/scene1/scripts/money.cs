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
    public void LoadField()
    {

        if (PlayerPrefs.HasKey("znachD"))
        {
            if (PlayerPrefs.GetInt("stoneD") == 0)
            {
                item = new Item(PlayerPrefs.GetInt("znachD"), PlayerPrefs.GetInt("stoneznachD"),false);
            }
            else 
            {
                item = new Item(PlayerPrefs.GetInt("znachD"), PlayerPrefs.GetInt("stoneznachD"), true);
            }
        }
        else item = new Item(0,0,false);
        //item = new Item(0, 0, false);
        znach = item.znachD;
        stoneznach = item.stoneznachD;
        if (item.stoneD)
        {
            Instantiate(stone, new Vector2(-0.78f, 2.45f), Quaternion.identity);
            GameObject A = Instantiate(stonescore, new Vector2(45.3f, 356.39f), Quaternion.identity);
            A.transform.SetParent(canvas.transform, false);
            A.GetComponent<Text>().text = stoneznach.ToString();
            GameObject B = Instantiate(stoneup, new Vector2(-1.552f, 1.108f), Quaternion.identity);
            B.transform.SetParent(shop.transform, false);
            textscr.dozens(stoneznach, ref A);
        }
        textscr.dozens(znach, ref score);
    }
    public void SaveField()
    {
        item.znachD = znach;
        item.stoneznachD = stoneznach;
        PlayerPrefs.SetInt("znachD", item.znachD);
        PlayerPrefs.SetInt("stoneznachD", item.stoneznachD);
        if (item.stoneD) PlayerPrefs.SetInt("stoneD",1);
        else PlayerPrefs.SetInt("stoneD",0);
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
        TurnOn(PlayerPrefs.GetInt("ReMineLvl")>0);
        LoadField();
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
    private void OnApplicationFocus(bool focus)
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
}
