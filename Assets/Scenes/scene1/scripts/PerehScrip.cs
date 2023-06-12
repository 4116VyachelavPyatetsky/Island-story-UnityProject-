using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerehScrip : MonoBehaviour
{
    public GameObject temn;
    void OnMouseDown()
    {
        if(money.znach >=200 && money.stoneznach >= 200)
        {
            money.znach -= 200;
            money.stoneznach -= 200;
            TemnScr A = temn.GetComponent<TemnScr>();
            A.scene = 1;
            SetVariablesToDefault();
            A.a = LoadSceneMode.Single;
            A.FadeToLevel();
        }
        gameObject.GetComponent<Animation>().Play("KnopAnim");
    }

    void SetVariablesToDefault()
    {
        planescr.maxhp = 10;
        planescr.hp = 10;
        planescr.harder = false;
        planescr.upgr = false;
        planescr.PlaneMoney = 0;
        wavescript.GivedItems = new List<int>();
        wavescript.AmmountOfMaps = 0;
        wavescript.gamestopped = true;
        wavescript.wavescomle = 0;
        wavescript.stuff = new List<int>();
        wavescript.boss = false;
        maijs.speed = 0.06f;
        gunscrfirst.angle = 0f;
        gunscrfirst.size = 1.0f;
        gunscrfirst.timebetweenShots = 0.13f;
        ShootRocket.amountOfRocket = 2;
        bullscript.bouncing = false;
        bullscript.homing = false;
        bullscript.Bullspeed = 10.8f;
        bullscript.dmg = 1;
        RocketScr.Radius = 0.8f;
        RocketScr.RocketDamage = 5;
        RocketScr.upgr = false;
        enemyhp.upgr = false;
        CoinScript.specItem = false;
        mapscr.pprelast = new int[]{ 0, 1 };
        mapscr.p = new int[] { 0, 1 };
    }
}
