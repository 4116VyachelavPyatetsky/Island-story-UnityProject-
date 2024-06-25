using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerToGO : MonoBehaviour
{
    float timer = 30;
    public Text timerText;
    private int chopforceUp;
    private int stoneforceUp;
    public static bool IsWorking = false;
    void Start()
    {
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IsWorking = false;
            treescrip.ChopForce -= chopforceUp;
            if (Stonescr.MineForce -stoneforceUp != 0) Stonescr.MineForce -= stoneforceUp;
            gameObject.SetActive(false);
        }
        timerText.text =Mathf.Round(timer).ToString();
    }
    public void StratADd()
    {
        IsWorking = true;
        timer = 30;
        timerText.text = timer.ToString();
        gameObject.SetActive(true);
        chopforceUp = treescrip.ChopForce;
        stoneforceUp = Stonescr.MineForce;
        treescrip.ChopForce *= 2;
        Stonescr.MineForce *= 2;

    }
}
