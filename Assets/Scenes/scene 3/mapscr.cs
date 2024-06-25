using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mapscr : MonoBehaviour
{
    public static int[] pprelast = { 0, 1 };
    public static int[] p = {0,1};//0;1
    public GameObject fon;
    GameObject hp;
    public GameObject tuman;
    public GameObject[] strelki;
    public GameObject[] ways;
    public GameObject Truba;
    public GameObject[] isles;
    int schet = 0;
    GameObject A;
    public static int[,] map = new int[6, 9];

    void Start()
    {
        if (Saves.TrubaBought !=0)
        {
            Truba.SetActive(true);
        }
        if (p[0] == 5)
        {
            p[0] = 0;
            p[1] = 1;
        }
        if (p[0] == 0 && p[1] == 1 )
        {
            mapcreating();
            MapSave();
        }
        //p[0] = PlayerPrefs.GetInt("y");
        //p[1] = PlayerPrefs.GetInt("x");
        /*Debug.Log(p[0]);
        Debug.Log(p[1]);*/
        mapreal();
        Ways();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mapclear();
            mapcreating();
            PlayerPrefs.DeleteKey("1");
        }
    }
    void proov(int a,int c)
    {
        switch (a)
        {
            case 3:
                if (map[c,a] >0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(-0.8f, -3.8f + 1.6f * c, 0.0f), Quaternion.identity, A.transform);
                }
                break;
            case 4:
                if (map[c, a] > 0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(0.8f, -3.8f + 1.6f * c, 0.0f), Quaternion.identity, A.transform);
                }
                break;
            case 5:
                if (map[c, a] > 0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(-0.8f, -3.0f + 1.6f * c, 0.0f), Quaternion.identity, A.transform);
                }
                break;
            case 6:
                if (map[c, a] > 0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(0.8f, -3.0f + 1.6f * c, 0.0f), Quaternion.identity, A.transform);
                }
                break;
            case 7:
                if (map[c, a] > 0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(-1.6f, -4.2f + 1.6f * (c+1), 0.0f), Quaternion.identity, A.transform);
                }
                break;
            case 8:
                if (map[c, a] > 0)
                {
                    Instantiate(ways[map[c, a]], new Vector3(1.6f, -4.2f + 1.6f * (c + 1), 0.0f), Quaternion.identity, A.transform);
                }
                break;
        }
    }
    void mapcreating()
    {
        for (int i = 0; i < 6; i++)
        {
            map[i, 0] = 1;
        }
        map[Random.Range(1, 5), 0] = 2;
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(1, 100);
            if (x >= 0 && x <= 45)
            {
                int b = Random.Range(1, 2);
                map[i, b] = 1;
                if (b == 1)
                {
                    if (i != 0 && map[i - 1, b] != 0)
                    {
                        
                        map[i - 1, 7] = 3;
                        map[i, 5] = 4;
                    }
                    else
                    {
                        map[i, 3] = 5;
                        map[i, 5] = 4;
                    }
                }
                if (b == 2)
                {
                    if (i != 0 && map[i - 1, b] != 0)
                    {
                        
                        map[i - 1, 8] = 3;
                        map[i, 6] = 4;
                    }
                    else
                    {
                        map[i, 6] = 5;
                        map[i, 4] = 4;
                    }
                }
            }
            if (x > 70 && x <= 100)
            {
                map[i, 1] = 1;
                map[i, 2] = 1;
                if (i != 0 && map[i - 1, 1] != 0)
                {
                    map[i - 1, 5] = -1;
                    map[i - 1, 7] = 3;
                    map[i, 5] = 4;
                }
                else
                {
                    map[i, 3] = 5;
                    map[i, 5] = 4;
                }
                if (i != 0 && map[i - 1, 2] != 0)
                {
                    map[i - 1, 6] = -1;
                    map[i - 1, 8] = 3;
                    map[i, 6] = 5;
                }
                else
                {
                    map[i, 6] = 5;
                    map[i, 4] = 4;
                }
            }
        }
        int l = 0;
        int r = 0;
        for (int i = 0; i < 5; i++)
        {
            if (map[i, 1] == 0)
            {
                if (r > 2)
                {
                    map[i - 1, 1] = 2;
                }
                r = 0;
            }
            else if (map[i, 1] == 1)
            {
                r += 1;
            }
            if (r == 2)
            {
                map[i, 1] = 3;
            }
            //
            if (map[i, 2] == 0)
            {
                if (l > 2)
                {
                    map[i - 1, 2] = 2;
                }
                l = 0;
            }
            else if (map[i, 2] == 1)
            {
                l += 1;
            }
            if (l == 2)
            {
                map[i, 2] = 3;
            }
        }
        bool w = false;
        int lw = 1;
        while (!w)
        {
            if (map[lw, 1] == 1 && map[lw + 1, 1] == 0)
            {
                if (Random.Range(1, 4 - lw) == 1)
                {
                    map[lw + 1, 1] = 3;
                    map[lw, 7] = 3;
                    if (map[lw + 2, 1] != 0)
                    {
                        map[lw + 1, 7] = 3;
                        map[lw + 2, 3] = -1;
                    }
                    else
                    {
                        map[lw + 1, 5] = 5;
                    }
                    map[lw, 5] = -1;
                    w = true;
                }
            }
            else if (map[lw, 2] == 1 && map[lw + 1, 2] == 0)
            {
                if (Random.Range(1, 4 - lw) == 1)
                {
                    map[lw + 1, 2] = 3;
                    map[lw, 8] = 3;
                    if (map[lw + 2, 2] != 0)
                    {
                        map[lw + 1, 8] = 3;
                        map[lw + 2, 4] = -1;
                    }
                    else
                    {
                        map[lw + 1, 6] = 5;
                    }
                    map[lw, 6] = -1;
                    w = true;
                }
            }
            lw++;
            if (lw == 4)
            {
                w = true;
            }

        }
        w = true;
        while (w)
        {
            for(int i = 0; i < 5; i++)
            {
                if(map[i,1]>=1 && Random.Range(1, 100) < 20)
                {
                    map[i, 1] = 2;
                    w = false;
                }
                if (map[i, 2] >= 1 && Random.Range(1, 100) < 20)
                {
                    map[i, 2] = 2;
                    w = false;
                }
            }
        }
    }
    void mapclear()
    {
        for (int i = 0; i< 6; i++)
        {
            for (int j = 0; j< 9; j++)
            {
                map[i, j] = 0;
            }
        }
        p[0] = 0;
        p[1] = 1;
    }
    void mapreal()
    {
        A = Instantiate(fon);
        float y1 = 0, y2 = 0,y3 = 0;
        switch (p[1])
        {
            case 2:
                y1 = -1.23f;
                y2 = -2.42f;
                y3 = -2.81f;
                break;
            case 1:
                y1 = -3.18f;
                y2 = -2.46f;
                y3 = -3.18f;
                break;
            case 0:
                y1 = -2.81f;
                y2 = -2.42f;
                y3 = -1.23f;
                break;
        }
        for (int i = p[0]; i < 6; i++)
        {
            Instantiate(tuman, new Vector3(-2.17f, y1 + i * 1.74f, 0), Quaternion.identity,A.transform);
            Instantiate(tuman, new Vector3(0, y2 + i * 1.74f, 0), Quaternion.identity, A.transform);
            Instantiate(tuman, new Vector3(2.14f, y3 + i * 1.74f, 0), Quaternion.identity, A.transform);
        }
        for (int i = 0; i < 6; i++)
        {
            if (i < 5)
            {
                Instantiate(ways[0], new Vector3(0.0f, -4.2f + 1.6f * i + 0.8f, 0.0f), Quaternion.identity, A.transform);
            }
            Instantiate(isles[map[i, 0] - 1], new Vector3(0.0f, -4.2f + 1.6f * i, 0.0f), Quaternion.identity, A.transform);
            if (map[i, 1] != 0)
            {
                Instantiate(isles[map[i, 1] - 1], new Vector3(-1.6f, -3.4f + 1.6f * i, 0.0f), Quaternion.identity, A.transform);
            }
            if (map[i, 2] != 0)
            {
                Instantiate(isles[map[i, 2] - 1], new Vector3(1.6f, -3.4f + 1.6f * i, 0.0f), Quaternion.identity, A.transform);
            }
            for (int j = 3; j < 9; j++)
            {
                if (i < 5)
                {
                    proov(j, i);
                }
            }
        }
    }
    void MapSave()
    {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    PlayerPrefs.SetInt((i * 9 + j).ToString(), (map[i, j - 1]));
                }
            }
    }
    void Ways()
    {
        switch (p[1])
        {
            case 2:
                if (map[p[0], 7] > 0) Instantiate(strelki[0], new Vector3(-1.6f, -2.4f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform); 
                if (map[p[0], 5] > 0) Instantiate(strelki[1], new Vector3(-0.88f, -3.173f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                break;
            case 1:
                Instantiate(strelki[0], new Vector3(0, -3.4f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                if (map[p[0], 3] > 0) Instantiate(strelki[2], new Vector3(-0.8f, -3.8f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                if (map[p[0], 4] > 0) Instantiate(strelki[1], new Vector3(0.8f, -3.8f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                break;
            case 0:
                if (map[p[0], 8] > 0) Instantiate(strelki[0], new Vector3(1.6f, -2.4f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                if (map[p[0], 6] > 0) Instantiate(strelki[2], new Vector3(0.88f, -3.173f + 1.6f * p[0], 0.0f), Quaternion.identity, A.transform);
                break;
        }
    }
}
