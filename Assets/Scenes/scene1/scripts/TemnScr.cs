using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemnScr : MonoBehaviour
{
    Animator anim;
    public LoadSceneMode a;
    public int scene;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }
    public void OnFadeComplete()
    {
        if (scene == -1)
        {
            Destroy(GameObject.Find("mapfon(Clone)"));
            SceneManager.UnloadSceneAsync(2);
            anim.SetTrigger("Fade");
            wavescript A = GameObject.Find("Main Camera").GetComponent<wavescript>();
            A.UIActive(true);
            StartCoroutine(A.animWait());
        }
        else if(scene == -2)
        {
            Saves.inshop = false;
            SceneManager.UnloadSceneAsync("SHop");
            SceneManager.LoadScene("scene map", LoadSceneMode.Additive);
            anim.SetTrigger("Fade");
        }
        else
        {
            SceneManager.LoadScene(scene, a);
            anim.SetTrigger("Fade");
        }
    }
}
