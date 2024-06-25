using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterRocketEffect : MonoBehaviour
{
    public AudioSource au;
    private void Start()
    {
        au.Play();
    }
    void AnimDeath()
    {
        Destroy(gameObject);
    }
}
