using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {

    public Slider sliderLife;
    public float maxLife;

    private bool isValid;

    private void Start()
    {
        isValid = true;
        sliderLife.maxValue = maxLife;
        sliderLife.value = myLife;
    }

    public override void ApplyDamage(float damage)
    {
        if (!isValid)
            return;
        base.ApplyDamage(damage);
        sliderLife.value = myLife;
        isValid = false;
        Invoke("Validate", 2f);
    }

    private void Validate()
    {
        isValid = true;
    }

    public override void Die()
    {
        base.Die();
    }

}
