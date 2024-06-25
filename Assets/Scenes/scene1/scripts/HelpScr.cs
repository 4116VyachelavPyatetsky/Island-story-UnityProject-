using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScr : MonoBehaviour
{
    bool showed = false;
    public void ShowOnOff()
    {
        if (!money.stoped)
        {
            showed = !showed;
            gameObject.SetActive(showed);
        }
    }
}
