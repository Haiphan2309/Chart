using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 targetPos;

    public Controller controllerScr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(transform.position);
        targetPos = transform.position;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (controllerScr.h0 != 0)
        {
            rb.velocity = Vector2.zero;
            transform.position = targetPos;
        }
    }
}
