using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyscript : MonoBehaviour
{
    public GameObject sky1, sky2;
    public GameObject Backsky1, Backsky2;
    public GameObject RealyBacksky1, RealyBacksky2;
    public GameObject Zadnik1, Zadnik2;
    void Update()
    {
        down(sky1,1.4f);
        down(sky2, 1.4f);
        down(Backsky1, 0.9f);
        down(Backsky2, 0.9f);
        down(RealyBacksky1, 0.3f);
        down(RealyBacksky2, 0.3f);
        downRes(Zadnik1, 0.2f);
        downRes(Zadnik2, 0.2f);
    }
    void down(GameObject sky,float speed)
    {
        sky.transform.position = Vector3.MoveTowards(sky.transform.position, new Vector3(0.0f, -11.0f, 0.0f), speed * Time.deltaTime);
        if(sky.transform.position.y <= -10.5f)
        {
            sky.transform.position = new Vector3(0.0f, 10.5f, 0.0f);
        }
    }
    void downRes(GameObject sky, float speed)
    {
        sky.transform.position = Vector3.MoveTowards(sky.transform.position, new Vector3(0.0f, -12.9f, 0.0f), speed * Time.deltaTime);
        if (sky.transform.position.y <= -12.8f)
        {
            sky.transform.position = new Vector3(0.0f, 12.8f, 0.0f);
        }
    }
}
