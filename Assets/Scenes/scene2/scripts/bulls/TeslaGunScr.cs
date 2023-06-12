using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaGunScr : MonoBehaviour
{
    public GameObject moln;
    bool isBusy = false;
    GameObject Wave;
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
        yield return new WaitForSeconds(2.0f);
        GameObject A = Instantiate(moln);
        A.GetComponent<LineRenderer>().SetPosition(0, transform.position - A.transform.position);
        A.GetComponent<LineRenderer>().SetPosition(1, DefineTearget() - A.transform.position);
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
