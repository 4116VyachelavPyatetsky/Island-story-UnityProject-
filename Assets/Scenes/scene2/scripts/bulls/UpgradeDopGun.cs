using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDopGun : MonoBehaviour
{
    public GameObject projectie;
    bool isBusy = false;
    AudioSource au;

    private void Start()
    {
        au = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!isBusy && !wavescript.gamestopped)
        {
            au.Play();
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        isBusy = true;
        yield return new WaitForSeconds(0.33f);
        //ShotSound.Play();
        GameObject A = Instantiate(projectie, new Vector3(gameObject.transform.position.x - 0.47f, gameObject.transform.position.y , 0.0f), Quaternion.identity);
        GameObject B = Instantiate(projectie, new Vector3(gameObject.transform.position.x + 0.47f, gameObject.transform.position.y , 0.0f), Quaternion.identity);
        yield return new WaitForSeconds(0.33f);
        isBusy = false;
    }
}
