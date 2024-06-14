using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Transform objTrans;
    public bool isShadowX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShadowX == false) transform.position = new Vector2(transform.position.x, objTrans.position.y);
        else transform.position = new Vector2(objTrans.position.x, transform.position.y);
    }
}
