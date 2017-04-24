using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {

    public Slider sliderLife;
    public float maxLife;
    public GameObject light;
    private bool isValid;

    private void Start()
    {
        isValid = true;
        light.SetActive(false);
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
        StartCoroutine("LightDamage");
        Invoke("Validate", 2f);
    }

    private IEnumerator LightDamage()
    {
        light.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        light.SetActive(false);
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
