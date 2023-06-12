using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoperAttide : MonoBehaviour
{
    public GameObject piedestal;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject A = Instantiate(piedestal, new Vector3(-2.22f + i * 1.5f, -1.85f  , 0), Quaternion.identity,transform);
            pedestalScr a = A.GetComponent<pedestalScr>();
            a.MakeIte(i);
        }
    }
}
