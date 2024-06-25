using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhp : MonoBehaviour
{
    public int hp;
    public int maxHP;
    public bool boss = false;
    public static bool upgr = false;
    SpriteRenderer spr;
    dragscr fiv;
    GameObject bo1, bo2, bo3;
    public GameObject health;
    public GameObject Rocket,hpram ;
    GameObject[] coins = new GameObject[2];
    public GameObject deathEffect;
    public Transform OtherObject;
    int ammount;
    int threatende=0;
    public bool spawnAnyOne = false;
    void Start()
    {
        if (boss)
        {
            health = GameObject.Find("BossHPRam");
        }
        if(gameObject.tag == "Snake")
        {
            ammount = transform.childCount;
            hp = transform.childCount * 5;
            OtherObject = transform.GetChild(transform.childCount/2-1);
        }
        hp *= 1;
        spr = GetComponent<SpriteRenderer>();
        coins[0] = Resources.Load("Money/COin") as GameObject;
        coins[1] = Resources.Load("Money/COin5") as GameObject;
        Rocket = Resources.Load("Money/rocketPickup") as GameObject;
        hpram = Resources.Load("hpRam/obr") as GameObject;
        deathEffect = Resources.Load("death effect_0") as GameObject;
        if (upgr && !boss)
        {
            if(gameObject.tag == "Snake")
            {
                health = Instantiate(hpram, OtherObject.position + new Vector3(0, 0.3f, 0), Quaternion.identity, GameObject.Find("hpnvas").transform);
            }
            else health = Instantiate(hpram,transform.position + new Vector3(0,0.3f,0),Quaternion.identity,GameObject.Find("hpnvas").transform);
        }
        if (wavescript.AmmountOfMaps == 2) {
            hp = Mathf.RoundToInt(hp * 1.5f); 
        }
        maxHP = hp;
        if (gameObject.tag == "drag")
        {
            fiv = gameObject.GetComponent<dragscr>();
            bo1 = fiv.b1;
            bo2 = fiv.b2;
            bo3 = fiv.b3;
        }
    }
    void FixedUpdate()
    {
        if (upgr && !boss)
        {
            if(gameObject.tag == "Snake") health.transform.position = OtherObject.position + new Vector3(0, 0.3f, 0);
            else health.transform.position = transform.position + new Vector3(0, 0.4f, 0);
            
        }
    }
    public void enemIsDamaged(int dmg)
    {
        hp-=dmg;
        if (upgr || boss)
        {
            health.transform.GetChild(0).localScale = new Vector2((float)hp / maxHP, 1.0f);
        }
        if (gameObject.tag == "Snake")
        {
            if (hp < (ammount - threatende-1) * 10*2)
            {
                GameObject N = transform.gameObject.GetComponent<SnakeEnem>().bodys[threatende];
                //if (threatende == ammount - 2) Loot(N.transform.position);
                Instantiate(deathEffect, N.transform.position, Quaternion.identity);
                Loot(N.transform.position,3);
                Destroy(N);
                threatende++;
                if (threatende == ammount) OtherObject = null;
                else OtherObject = transform.gameObject.GetComponent<SnakeEnem>().bodys[threatende].transform;
            }
        }
        if (hp <= 0) {
            if (spawnAnyOne)
            {
                gameObject.GetComponent<LeachMobe>().DopEnemSpawn();
            }
            if (boss)
            {
                health.SetActive(false);
            }
            else if (upgr)Destroy(health);
            if (gameObject.tag != "Snake")
            {
                if(deathEffect != null)
                {
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                }
                Loot(transform.position);
            }
            if(transform.parent.gameObject.tag == "pvt")
            {
                Destroy(transform.parent.gameObject);
            }
            else if (gameObject.tag == "enemy" || gameObject.tag == "Snake")
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "drag")
            {
                Instantiate(deathEffect, bo1.transform.position, Quaternion.identity);
                Destroy(bo1);
                Instantiate(deathEffect, bo2.transform.position, Quaternion.identity);
                Destroy(bo2);
                Instantiate(deathEffect, bo3.transform.position, Quaternion.identity);
                Destroy(bo3);
                Destroy(gameObject);
            }
        }
        else StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        for(int i = 0; i < 3; i++)
        {
            spr.color = new Color(1.0f, 0.55f, 0.55f, 1f);
            foreach(Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.55f, 0.55f, 1f);
            }
            yield return new WaitForSeconds(0.06f);
            spr.color = new Color(1.0f, 1f, 1f, 1f);
            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1f, 1f, 1f);
            }
            yield return new WaitForSeconds(0.06f);
        }
    }
    void Loot(Vector3 x,int lowerChance=0)
    {
            if (Random.Range(0, 4+ lowerChance) == 0)
            {
                if(Random.Range(0,5)<=3)Instantiate(coins[0], x, Quaternion.identity);
                else Instantiate(coins[1], x, Quaternion.identity);
            }
            else if (Random.Range(0, 7+lowerChance) == 0)
            {
                Instantiate(Rocket, x, Quaternion.identity);
            }
    }
}
