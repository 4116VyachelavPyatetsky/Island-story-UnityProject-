using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndScr : MonoBehaviour
{
    public GameObject image;
    public wavescript mncamera;
    public void ClosePlaneLevel()
    {
        wavescript.gamestopped = true;
        mncamera.StopTheGame();
        TemnScr b = image.GetComponent<TemnScr>();
        b.scene = 0;
        b.a = LoadSceneMode.Single;
        b.FadeToLevel();
        Destroy(gameObject);
    }
}
