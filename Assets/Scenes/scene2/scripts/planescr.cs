
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class planescr : MonoBehaviour
{
    bool isBusy = false;
    int npr = 0;
    public static int PlaneMoney = 0;
    Animator anim;
    public GameObject image;
    public static int maxhp = 10;
    public static int hp = 10;
    public static bool harder = false;
    public static bool upgr = false;
    GameObject planehp;
    GameObject Text1;
    GameObject MoneyText;
    void Start()
    {
        npr = Random.Range(0, 2);
        /*
        if (PlayerPrefs.HasKey("hp"))
        {
            maxhp = PlayerPrefs.GetInt("maxhp");
            hp = PlayerPrefs.GetInt("hp");
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("spritename"));
        }*/
        anim = gameObject.GetComponent<Animator>();
        Text1 = GameObject.Find("helattet");
        MoneyText = GameObject.Find("CoinText");
        planehp = GameObject.Find("hp");
        hp++;
        OnDamage();
        PlusMoney(0);
    }
    void Update()
    {
        if (harder)
        {
            Wind(npr) ;
        }
        if (gameObject.transform.position.x > 2.36f)
        {
            gameObject.transform.position = new Vector3(2.36f, gameObject.transform.position.y, 0.0f);
        }
        if (gameObject.transform.position.x < -2.36f)
        {
            gameObject.transform.position = new Vector3(-2.36f, gameObject.transform.position.y, 0.0f);
        }
        if (gameObject.transform.position.y > 4.36f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 4.36f, 0.0f);
        }
        if (gameObject.transform.position.y < -4.36f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4.36f, 0.0f);
        }
    }
    public void OnDamage()
    {
        if (!isBusy)
        {
            hp--;
            planehp.transform.localScale = new Vector2((float)hp/maxhp, 1.0f);
            Text1.GetComponent<Text>().text = hp.ToString() + "/" + maxhp.ToString();
            if (hp <= 0)
            {
                wavescript.gamestopped = true;
                TemnScr b = image.GetComponent<TemnScr>();
                b.scene = 0;
                b.a = LoadSceneMode.Single;
                b.FadeToLevel();
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Wait());
            }
        }
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (upgr)
        {
            if (lel.gameObject.tag == "enemy" || lel.gameObject.tag == "drag")
            {
                enemyhp fiv = lel.GetComponent<enemyhp>();
                fiv.enemIsDamaged(5);
            }
        }
    }
    public void PlusMoney(int GotMon)
    {
        PlaneMoney += GotMon;
        MoneyText.GetComponent<Text>().text = PlaneMoney.ToString();
    }
    IEnumerator Wait()
    {
        anim.SetBool("isDamaged", true);
        isBusy = true;
        gameObject.tag = "DamagedPlayer";
        yield return new WaitForSeconds(1.0f);
        gameObject.tag = "Player";
        isBusy = false;
        anim.SetBool("isDamaged", false);
    }
    private void Wind(int napr)
    {
        if (napr == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 100.0f, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 100.0f, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);
        }
    }
}
