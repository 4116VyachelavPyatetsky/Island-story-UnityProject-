using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaGunScr : MonoBehaviour
{
    public GameObject moln;
    bool isBusy = false;
    GameObject Wave;

    AudioSource au;

    private void Start()
    {
        au = GetComponent<AudioSource>();
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
        if (GameObject.Find("Main Camera").GetComponent<wavescript>().wave.transform.childCount > 0)
        {
            yield return new WaitForSeconds(1.3f);
            au.Play();
            yield return new WaitForSeconds(2.7f);
            Debug.Log("dad");
            GameObject A = Instantiate(moln);
            Vector3 targ = DefineTearget();
            if (!(targ.y >= 5.2f * wavescript.screenSizePere || targ.x >= 3.2f || targ.x <= -3.2f))
            {
                A.GetComponent<LineRenderer>().SetPosition(0, transform.position - A.transform.position);
                A.GetComponent<LineRenderer>().SetPosition(1, targ - A.transform.position);
            }
            else
            {
                A.GetComponent<LineRenderer>().SetPosition(0, transform.position - A.transform.position);
                A.GetComponent<LineRenderer>().SetPosition(1, transform.position - A.transform.position);
            }
        }
        isBusy = false;
    }
    Vector3 DefineTearget()
    {
        Wave = GameObject.Find("Main Camera").GetComponent<wavescript>().wave;
        Transform b = Wave.transform.GetChild(Random.Range(0, Wave.transform.childCount));
        if (b.tag == "pvt") b = b.GetChild(0);
        else if(b.tag == "Snake") b = b.GetChild(Random.Range(0, b.childCount));
        return (b.position);
    }
}
