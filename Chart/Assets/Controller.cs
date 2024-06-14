using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Text textH0,textV0, textAlpha0;
    public float h0, v0, alpha0;

    [SerializeField] SimulatePhysic simulateObj;

    public ParticleSystem vfx;
    ParticleSystem vfxObj;

    public void SetH0()
    {
        h0 = float.Parse(textH0.text);
        ResetObjPos();
    }
    public void SetV0()
    {
        v0 = float.Parse(textV0.text);
        ResetObjPos();
    }
    public void SetAlpha0()
    {
        alpha0 = float.Parse(textAlpha0.text);
        ResetObjPos();
    }

    void ResetObjPos()
    {
        simulateObj.Setup(v0,alpha0,h0);
    }

    public void Move()
    {
        Destroy(vfxObj);
        vfxObj = Instantiate(vfx, simulateObj.transform.position, Quaternion.identity);
        vfxObj.transform.SetParent(simulateObj.transform);
        ResetObjPos();
        simulateObj.StartSimulate();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
