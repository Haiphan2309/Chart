using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SimulatePhysic : MonoBehaviour
{
    float height, t;
    [SerializeField] float deltaT; //thoi gian giua cac frame simulate
    [SerializeField] float lossPercent;

    Vector2 v;
    float tx = 0;

    Coroutine simulateCor;
    public void Setup(float v0, float alpha0, float height)
    {
        this.height = height;
        t = 0;
        tx = 0;
        v = new Vector2(Mathf.Cos(alpha0 * Mathf.PI / 180f), Mathf.Sin(alpha0 * Mathf.PI / 180f)) * v0;
        UpdateSimulate();
    }
    public void StartSimulate()
    {
        simulateCor = StartCoroutine(Cor_Simulate());
    }
    void UpdateSimulate()
    {
        float x = 0 + v.x * (t + tx);
        float y = height + v.y * t - 0.5f * 9.8f * t*t;
        if (y<0)
        {
            tx += t;
            v.y = -(v.y - 9.8f*t) * (1 - lossPercent);
            t = 0;
            height = 0;
            y = 0;
        }
        transform.position = new Vector3(x, y, 0);
    }
    IEnumerator Cor_Simulate()
    {
        yield return new WaitForSeconds(deltaT);
        UpdateSimulate();
        t += deltaT;
        simulateCor = StartCoroutine(Cor_Simulate());
    }
}
