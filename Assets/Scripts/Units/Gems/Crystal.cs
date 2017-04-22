using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public Crystals crystalConfig;
    [SerializeField]
    private bool isFirstActive = true;

    public float amount;

    private void OnEnable()
    {
        if (isFirstActive)
        {
            amount = crystalConfig.amount;
            isFirstActive = false;
        }
    }

    public float Extract(){
        float exAmount = 0f;
        if(amount > 0f){
            exAmount = amount;
        }
        amount -= exAmount;
        return exAmount;
    }

}
