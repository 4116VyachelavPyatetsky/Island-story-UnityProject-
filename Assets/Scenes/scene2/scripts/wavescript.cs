using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class wavescript : MonoBehaviour
{
    public static float screenSizePere;
    public GameObject lil;
    bool stoped = false;
    public static int AmmountOfMaps = 0;
    public static List<int> GivedItems = new List<int>();
    public GameObject wave,RocketTxt,RocketButton,Rck_img,Rck_img_sc;
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

    public GameObject bossRam;

    public AudioSource au;
    bool change = false;

    public GameObject Menu,menu_temn;

    private void Awake()
    {
        float a = Screen.width;
        float b = Screen.height;
        screenSizePere = (b / a) / (800f / 480f);
    }
    void Start()
    {
        StopTheGame();
        StopTheGame();
        au.ignoreListenerPause = true;
        PlayerPrefs.SetInt("y", 0); PlayerPrefs.SetInt("x", 1);
        wave = Instantiate(waves[ChooseWave()]);
        //wave = Instantiate(waves[28]);
        //BossWave();
        ch = wave.transform.childCount;
        ram = GameObject.Find("ram");
        StartCoroutine(animWait());
    }
    void Update()
    {
        if (!gamestopped) 
        {
            if (au.volume < 0.8f) au.volume += 0.0005f;
            wave.transform.position = Vector3.MoveTowards(wave.transform.position, new Vector3(wave.transform.position.x, -2.56f, 0.0f), 3f * Time.deltaTime);
            ch = wave.transform.childCount;
            if (ch == 0)
            {
                wavescomle++;
                if (wavescomle == AmountWaves)
                {
                    //au.volume = 0.02f;
                    schetVoln++;
                    if(schetVoln == 4)
                    {
                        usedwaves.RemoveRange(0, 4);
                        schetVoln = 0;
                    }
                    if (AmmountOfMaps == 2)
                    {
                        Back_to_Island();
                    }
                    else
                    {
                        gamestopped = true;
                        int x = PlayerPrefs.GetInt("x") + 1;

                        if (x == 1) x = 3;
                        else if (x == 2) x = 1;
                        else if (x == 3) x = 2;
                        int c = PlayerPrefs.GetInt((x + (PlayerPrefs.GetInt("y")) * 9).ToString());
                        if (c == 2)
                        {
                            Instantiate(upgr);
                        }
                        else if (c == 3)
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
                    }
                    //Destroy(wave);
                }
                else
                {
                    Again();
                }
            }
        }
        else
        {
            if (au.volume > 0.02f && change) au.volume -= 0.0005f;
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
        change = true;
        //au.volume = 0.06f;
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
        StartCoroutine(Wait_for_boss());
    }
    public void UIActive(bool a)
    {
        RocketButton.SetActive(a);
        RocketTxt.SetActive(a);
        Rck_img.SetActive(a);
        Rck_img_sc.SetActive(a);
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
    public void StopTheGame()
    {
        if (!stoped)
        {
            //listen.pause = true;
            AudioListener.pause = true;
            Time.timeScale = 0;
            stoped = true;
            //gamestopped = true;
            lil.GetComponent<BoxCollider2D>().enabled = !stoped;
        }
        else
        {
            AudioListener.pause = false;
            Time.timeScale = 1;
            stoped = false;
            //gamestopped = false;
            lil.GetComponent<BoxCollider2D>().enabled = !stoped;
        }
        Menu.SetActive(stoped);
        menu_temn.SetActive(stoped);
    }

    public void StopForAd()
    {
        if (!stoped)
        {
            //listen.pause = true;
            AudioListener.pause = true;
            Time.timeScale = 0;
            stoped = true;
            gamestopped = true;
            lil.GetComponent<BoxCollider2D>().enabled = !stoped;
        }
        else
        {
            AudioListener.pause = false;
            Time.timeScale = 1;
            stoped = false;
            gamestopped = false;
            lil.GetComponent<BoxCollider2D>().enabled = !stoped;
        }
    }
    public void Back_to_Island()
    {
        scenepereh.GetComponent<TemnScr>().scene = 0;
        scenepereh.GetComponent<TemnScr>().a = LoadSceneMode.Single;
        scenepereh.GetComponent<TemnScr>().FadeToLevel();
    }

    IEnumerator Wait_for_boss()
    {
        yield return new WaitForSeconds(1.2f);
        bossRam.SetActive(true);
        if (AmmountOfMaps == 0) wave = Instantiate(Bosswaves[0]);
        else wave = Instantiate(Bosswaves[1]);
        AmmountOfMaps++;
        wavescomle = AmountWaves - 1;
    }
}
