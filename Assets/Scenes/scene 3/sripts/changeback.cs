using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeback : MonoBehaviour
{
    public static void change()
    {
        if (mapscr.p[0] >= 5)
        {
            GameObject cam = GameObject.Find("Main Camera");
            wavescript a = cam.GetComponent<wavescript>();
            a.BossWave();
        }

        if (mapscr.p[1]==1 && mapscr.pprelast[1] == 1)
        {
            planescr.harder = false;
        }
        else
        {
            planescr.harder = true;
        }
        PlayerPrefs.SetInt("y", mapscr.p[0]); PlayerPrefs.SetInt("x", mapscr.p[1]);
        //SceneManager.LoadScene("sce2", LoadSceneMode.Single);
        TemnScr B = GameObject.Find("Image").GetComponent<TemnScr>();
        B.scene = -1;
        B.FadeToLevel();
    }
}
