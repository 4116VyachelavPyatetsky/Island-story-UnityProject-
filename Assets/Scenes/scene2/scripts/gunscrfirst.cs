using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscrfirst : MonoBehaviour
{
    public GameObject projectie;
    public static float angle = 0;
    bool isBusy = false;
    public static float size= 1.0f;
    public static float timebetweenShots = 0.13f;
    AudioSource ShotSound;
    private void Start()
    {
        ShotSound = gameObject.GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("dmg")) size = PlayerPrefs.GetFloat("size");
    }
    void Update()
    {
        if (!isBusy && !wavescript.gamestopped)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        isBusy = true;
        yield return new WaitForSeconds(timebetweenShots);
        ShotSound.Play();
        GameObject A = Instantiate(projectie, new Vector3(gameObject.transform.position.x -0.257f, gameObject.transform.position.y + 0.56f, 0.0f), Quaternion.identity);
        GameObject B = Instantiate(projectie, new Vector3(gameObject.transform.position.x + 0.257f, gameObject.transform.position.y + 0.56f, 0.0f), Quaternion.identity);
        A.GetComponent<bullscript>().Angle = angle;
        B.GetComponent<bullscript>().Angle = -angle;
        A.transform.rotation = Quaternion.Euler(0,0,-angle);
        B.transform.rotation = Quaternion.Euler(0, 0, angle);
        A.transform.localScale = new Vector3(1.0f*size, 1.0f*size, 1.0f);
        B.transform.localScale = new Vector3(1.0f*size, 1.0f*size, 1.0f);
        yield return new WaitForSeconds(timebetweenShots);
        isBusy = false;
    }
}
