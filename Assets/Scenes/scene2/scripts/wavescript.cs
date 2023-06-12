using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class wavescript : MonoBehaviour
{
    public static int AmmountOfMaps = 0;
    public static List<int> GivedItems = new List<int>();
    public GameObject wave,RocketTxt,RocketButton;
    public GameObject upgr;
    public GameObject[] waves;
    public GameObject[] Bosswaves;
    public GameObject scenepereh;
    int schetVoln = 0;
    Animator an;
    GameObject ram;
    int AmountWaves = 4;
    List<int> usedwaves = new List<int>();
    int ch;
    public static bool gamestopped = true;
    public static int wavescomle = 0;
    public static List<int> stuff;
    public static bool boss = false;
    void Start()
    {
        PlayerPrefs.SetInt("y", 0); PlayerPrefs.SetInt("x", 1);
        //wave = Instantiate(waves[ChooseWave()]);
        wave = Instantiate(waves[28]);
        ch = wave.transform.childCount;
        ram = GameObject.Find("ram");
        StartCoroutine(animWait());
    }
    void Update()
    {
        if (!gamestopped) 
        {
            wave.transform.position = Vector3.MoveTowards(wave.transform.position, new Vector3(wave.transform.position.x, -2.56f, 0.0f), 3f * Time.deltaTime);
            ch = wave.transform.childCount;
            if (ch == 0)
            {
                wavescomle++;
                if (wavescomle == AmountWaves)
                {
                    schetVoln++;
                    if(schetVoln == 2)
                    {
                        usedwaves.RemoveRange(0, 4);
                        schetVoln = 0;
                    }
                    if(AmmountOfMaps == 2)
                    {
                        scenepereh.GetComponent<TemnScr>().scene = 0;
                        scenepereh.GetComponent<TemnScr>().a = LoadSceneMode.Single;
                        scenepereh.GetComponent<TemnScr>().FadeToLevel();
                    }
                    gamestopped = true;
                    int x = PlayerPrefs.GetInt("x")  +1;
                    
                    if (x == 1) x = 3;
                    else if (x == 2) x = 1;
                    else if (x == 3) x = 2;
                    int c = PlayerPrefs.GetInt((x  + (PlayerPrefs.GetInt("y")) * 9).ToString());
                    Debug.Log(x);
                    Debug.Log(PlayerPrefs.GetInt("y"));
                    if (c==2)
                    {
                       Instantiate(upgr);
                    }
                    else if(c == 3)
                    {
                        UIActive(false);
                        Saves.inshop = true;
                        wavescomle = 0;
                        scenepereh.GetComponent<TemnScr>().scene = 3;
                        scenepereh.GetComponent<TemnScr>().a = LoadSceneMode.Additive;
                        scenepereh.GetComponent<TemnScr>().FadeToLevel();
                        Again();
                    }
                    else
                    {
                        wavescomle = 0;
                        changemapscene.Change();
                    }
                    //Destroy(wave);
                }
                else
                {
                    Again();
                }
            }
        }
    }
    void OnDisable()
    {
        /*
        for(int i = 0; i < stuff.Count; i++)
        {
            PlayerPrefs.SetInt(i.ToString() + "List",stuff[i]);
        }*/
    }
    public IEnumerator animWait()
    {
        yield return new WaitForSeconds(1.0f);
        gamestopped = false;
    }
    public void Again()
    {
        Destroy(wave);
        wave = Instantiate(waves[ChooseWave()]);
        ch = wave.transform.childCount;
    }
    public void BossWave()
    {
        Destroy(wave);
        if(AmmountOfMaps == 0)wave = Instantiate(Bosswaves[0]);
        else wave = Instantiate(Bosswaves[1]);
        AmmountOfMaps++;
        wavescomle = AmountWaves - 1;
    }
    public void UIActive(bool a)
    {
        RocketButton.SetActive(a);
        RocketTxt.SetActive(a);
    }
    int ChooseWave()
    {
        int x = Random.Range(0, waves.Length);
        while (usedwaves.Contains(x))
        {
            x = Random.Range(0, waves.Length);
        }
        usedwaves.Add(x);
        return (x);
    }
}
