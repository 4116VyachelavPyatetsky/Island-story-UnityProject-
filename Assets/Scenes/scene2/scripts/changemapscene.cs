using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class changemapscene : MonoBehaviour
{
    public static void Change()
    {
        GameObject.Find("Main Camera").GetComponent<wavescript>().UIActive(false);
        wavescript.gamestopped = true;
        wavescript.wavescomle = 0;
        GameObject b = GameObject.Find("Main Camera");
        wavescript a = b.GetComponent<wavescript>();
        a.Again();
        TemnScr A = GameObject.Find("Image").GetComponent<TemnScr>();
        A.scene = 2;
        A.a = LoadSceneMode.Additive;
        A.FadeToLevel();
    }
}
