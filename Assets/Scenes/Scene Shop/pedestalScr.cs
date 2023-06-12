using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestalScr : MonoBehaviour
{
    public GameObject[] ite;
    public void MakeIte(int i)
    {
        GameObject B = Instantiate(ite[i],transform.position + new Vector3(0,1.2f,0), Quaternion.identity,transform);
        B.GetComponent<CostScript>().number = i;
    }
}
