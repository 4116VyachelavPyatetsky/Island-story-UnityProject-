using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanEnemHead : MonoBehaviour
{
    GameObject plane;
    public GameObject bull;
    bool isBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("plane");
    }

    // Update is called once per frame
    void Update()
    {
        if (!wavescript.gamestopped)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(plane.transform.position.y - transform.position.y, plane.transform.position.x - transform.position.x) * Mathf.Rad2Deg + 90);
            if (!isBusy)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        isBusy = true;
        for (int i = 0; i < 2; i++)
        {
            GameObject A = Instantiate(bull, gameObject.transform.position, Quaternion.identity);
            Vector3 promej = plane.transform.position;
            A.GetComponent<projscript>().rastoynie = promej + (promej - transform.position) * 10;
            A.GetComponent<projscript>().Vzriv = false;
            A.GetComponent<projscript>().projSpeed = 6f;
            Animator anim = A.GetComponent<Animator>();
            anim.SetBool("bulltype", true);
            A.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(3.0f);
        isBusy = false;
    }
}
