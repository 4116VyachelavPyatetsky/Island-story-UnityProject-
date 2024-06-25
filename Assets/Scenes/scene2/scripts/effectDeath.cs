using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDeath : MonoBehaviour
{
    public AudioClip cl;
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(cl);
    }
    void End()
    {
        Destroy(gameObject);
    }
}
