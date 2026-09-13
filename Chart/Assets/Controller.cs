using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public InputField textH0,textV0, textAlpha0;
    public float h0, v0, alpha0;

    [SerializeField] SimulatePhysic simulateObj;

    public ParticleSystem vfx;
    ParticleSystem vfxObj;

    private void Start()
    {
        textH0.onValueChanged.AddListener(SetH0);
        textV0.onValueChanged.AddListener(SetV0);
        textAlpha0.onValueChanged.AddListener(SetAlpha0);
    }

    public void SetH0(string value)
    {
        h0 = float.Parse(value);
        ResetObjPos();
        simulateObj.StopSimulate();
    }
    public void SetV0(string value)
    {
        v0 = float.Parse(value);
        ResetObjPos();
        simulateObj.StopSimulate();
    }
    public void SetAlpha0(string value)
    {
        alpha0 = float.Parse(value);
        ResetObjPos();
        simulateObj.StopSimulate();
    }

    void ResetObjPos()
    {
        simulateObj.Setup(v0,alpha0,h0);
    }

    public void Move()
    {
        if (vfxObj)
        {
            Destroy(vfxObj);
        }
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
