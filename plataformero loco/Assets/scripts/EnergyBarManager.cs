using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarManager : MonoBehaviour
{
    [SerializeField] private GameObject Bar;
    [SerializeField] private Renderer barColor;
    [SerializeField] private float Energy;
    [SerializeField] private float normEnergy;
    [SerializeField] private float maxEnergy = 100;
    [SerializeField] private float minEnergy = 0;
    [SerializeField] private float Drain;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        float i = Mathf.InverseLerp(minEnergy, maxEnergy, Energy);
        normEnergy = i;
        if (Energy <= minEnergy)
        {
            Energy = minEnergy;
        }
        if (Energy >= maxEnergy)
        {
            Energy = maxEnergy;
        }
        if (i >= 1f)
        {
            barColor.material.color = Color.green;
        }
        if (i > 0.6f && i < 0.99f)
        {
            barColor.material.color = Color.blue;
        }
        if (i > 0.3f && i < 0.6f)
        {
            barColor.material.color = Color.yellow;
        }
        if (i < 0.3f)
        {
            barColor.material.color = Color.red;
        }
        Energy -= Drain * Time.deltaTime;
        Bar.transform.localScale = new Vector3(Bar.transform.localScale.x, i,Bar.transform.localScale.z);
    }

    public void recharge(float rechargeRate)
    {
        Debug.Log("recharging" + rechargeRate);
        Energy += rechargeRate * Time.deltaTime;
    }
}
