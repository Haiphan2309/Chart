using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorV : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D rb;

    LineRenderer lr;

    public bool isVx;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity == Vector2.zero) transform.localScale = Vector2.zero;
        else transform.localScale = new Vector2(1.5f, 1.5f);

        if (isVx)
        {
            transform.position = trans.position + new Vector3(rb.velocity.x/3f, 0, 0);
        }
        else
        {
            if (rb.velocity.y > 0)
                transform.rotation = Quaternion.Euler(0, 0, 90);
            else
                transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position = trans.position + new Vector3(0, rb.velocity.y/3f, 0);
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, trans.position);
    }
}
