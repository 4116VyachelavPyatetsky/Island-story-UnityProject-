using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScr : MonoBehaviour
{
    EdgeCollider2D coll;
    LineRenderer line;
    public GameObject start;
    private void Start()
    {
        coll = gameObject.GetComponent<EdgeCollider2D>();
        line = gameObject.GetComponent<LineRenderer>();
        oprEdges();
        Instantiate(start, line.GetPosition(0)+transform.position, Quaternion.identity, transform);
    }
    void oprEdges()
    {
        List<Vector2> edge = new List<Vector2>();
        Vector3 dopPos = (line.GetPosition(1) - line.GetPosition(0)).normalized * 0.18f;
        dopPos = new Vector3(dopPos.y, -dopPos.x, 0);
        for (int i = 0; i < line.positionCount; i++)
        {
            Vector3 linePoint = line.GetPosition(i);
            edge.Add(new Vector2(linePoint.x- dopPos.x, linePoint.y-dopPos.y));
            edge.Add(new Vector2(linePoint.x +dopPos.x, linePoint.y + dopPos.y));
            dopPos *= -1;
        }
        edge.Add(edge[0]);
        coll.SetPoints(edge);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            planescr fiv = collision.GetComponent<planescr>();
            fiv.OnDamage();
        }
    }
    public void destr()
    {
        Destroy(gameObject);
    }
}
