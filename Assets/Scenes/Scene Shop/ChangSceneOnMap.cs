using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangSceneOnMap : MonoBehaviour
{
    GameObject pereh;
    TemnScr A;
    private void Start()
    {
        pereh = GameObject.Find("Image");
        A = pereh.GetComponent<TemnScr>();
        A.scene = -2;
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<Animation>().Play("KnopAnim");
        A.FadeToLevel();
    }
}
