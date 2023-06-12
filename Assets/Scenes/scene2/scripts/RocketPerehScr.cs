using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPerehScr : MonoBehaviour
{
    public GameObject a;
    ShootRocket b;
    private void Start()
    {
        b = a.GetComponent<ShootRocket>();
    }
    void End()
    {
        b.Untrigger();
    }
}
