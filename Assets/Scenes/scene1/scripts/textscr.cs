using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textscr : MonoBehaviour
{
    public static void dozens(int znach,ref GameObject txt)
    {
        string[] dozen = new string[] { "k", "m", "b", "t", "qua", "qui", "sext", "sep", "o", "n" };
        int num = znach;
        int i = 0;
        while (num > 1)
        {
            i++;
            num /= 10;
        }
        i--;
        if (i > 2)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Mathf.Floor(i / ((j + 1) * 3)) < 2)
                {
                    num = Mathf.RoundToInt(Mathf.Pow(10, ((j + 1) * 3)-1));
                    znach /= num;
                    float b = znach / 10.0f;
                    txt.GetComponent<Text>().text = b.ToString() + dozen[j];
                    break;
                }
            }
        }
        else
        {
            txt.GetComponent<Text>().text = znach.ToString();

        }
    }
    //textscr.dozens()
}
