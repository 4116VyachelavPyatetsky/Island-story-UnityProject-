
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class planescr : MonoBehaviour
{
    public GameObject expl;
    bool isBusy = false;
    int npr = 0;
    public static int PlaneMoney = 0;
    Animator anim;
    float ResPeremen;
    public static int maxhp = 10;
    public static int hp = 10;
    public static bool harder = false;
    public static bool upgr = false;
    public static int AmmpuntOfComers =0;
    public GameObject Comersial;
    GameObject planehp;
    GameObject Text1;
    GameObject MoneyText;
    public wavescript mcamera;
    public GameEndScr end;
    AudioSource au;
    public AudioClip clipMoney;
    public AudioClip clipDamage;
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        float a = Screen.height;
        float b = Screen.width;
        ResPeremen = (a / b) / (800f / 480f);
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
        //hp++;
        Text1.GetComponent<Text>().text = hp.ToString() + "/" + maxhp.ToString();
        //OnDamage();
        MoneyText.GetComponent<Text>().text = PlaneMoney.ToString();
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
        if (gameObject.transform.position.y > 4.36f * ResPeremen)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 4.36f * ResPeremen, 0.0f);
        }
        if (gameObject.transform.position.y < -4.36f * ResPeremen)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4.36f * ResPeremen, 0.0f);
        }
    }
    public void OnDamage()
    {
        if (!isBusy)
        {
            hp--;
            au.PlayOneShot(clipDamage);
            StartCoroutine(Wait());
            UpdateText();
            if (hp <= 0)
            {
                isBusy = true;
                //gameObject.SetActive(false);
                wavescript.gamestopped = true;
                Instantiate(expl, transform.position, Quaternion.identity);
                mcamera.StopForAd();
                if (AmmpuntOfComers >= 1)
                {
                    end.ClosePlaneLevel();
                    Destroy(gameObject);
                }
                else
                {
                    Comersial.SetActive(true);
                }
            }
            else
            {
                StartCoroutine(Wait());
            }
        }
    }

    public void UpdateText()
    {
        planehp.transform.localScale = new Vector2((float)hp / maxhp, 1.0f);
        Text1.GetComponent<Text>().text = hp.ToString() + "/" + maxhp.ToString();
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
            if (lel.gameObject.tag == "body")
            {
                if (lel.transform.parent != null)
                {
                    lel.gameObject.transform.parent.gameObject.GetComponent<enemyhp>().enemIsDamaged(5);
                }
                else lel.gameObject.GetComponent<dragbodyscr>().head.GetComponent<enemyhp>().enemIsDamaged(5);
            }
        }
    }
    public void PlusMoney(int GotMon)
    {
        au.PlayOneShot(clipMoney);
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
