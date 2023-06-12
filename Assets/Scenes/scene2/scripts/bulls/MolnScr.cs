using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolnScr : MonoBehaviour
{
    EdgeCollider2D coll;
    LineRenderer line;
    public Texture[] textures;
    Sprite spr;
    bool isbusy = false;
    private int schet = 0;
    public GameObject effect;
    private void Start()
    {
        coll = gameObject.GetComponent<EdgeCollider2D>();
        line = gameObject.GetComponent<LineRenderer>();
        oprEdges();
        Instantiate(effect, line.GetPosition(0) + transform.position, Quaternion.identity, transform);
        Instantiate(effect, line.GetPosition(1) + transform.position, Quaternion.identity, transform);
    }
    void oprEdges()
    {
        List<Vector2> edge = new List<Vector2>();
        Vector3 dopPos = (line.GetPosition(1) - line.GetPosition(0)).normalized * 0.09f;
        dopPos = new Vector3(dopPos.y, -dopPos.x, 0);
        for (int i = 0; i < line.positionCount; i++)
        {
            Vector3 linePoint = line.GetPosition(i);
            edge.Add(new Vector2(linePoint.x - dopPos.x, linePoint.y - dopPos.y));
            edge.Add(new Vector2(linePoint.x + dopPos.x, linePoint.y + dopPos.y));
            dopPos *= -1;
        }
        edge.Add(edge[0]);
        coll.SetPoints(edge);
    }
    private void FixedUpdate()
    {
        if (!isbusy)
        {
            StartCoroutine(Anm());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "drag")
        {
            enemyhp fiv = collision.GetComponent<enemyhp>();
            fiv.enemIsDamaged(4);
        }
        if (collision.gameObject.tag == "body")
        {
            if (collision.transform.parent != null)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<enemyhp>().enemIsDamaged(4);
            }
            else collision.gameObject.GetComponent<dragbodyscr>().head.GetComponent<enemyhp>().enemIsDamaged(4);
        }
    }
    IEnumerator Anm()
    {
        isbusy = true;
        yield return new WaitForSeconds(0.1f);
        line.material.SetTexture("_MainTex", textures[schet%4]);
        schet++;
        if (schet == 8)
        {
            Destroy(gameObject);
        }
        isbusy = false;

    }
}
