using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public Crystals crystalConfig;
    [SerializeField]
    private bool isFirstActive = true;

    public ParticleSystem particles;

    public float amount;

    private void OnEnable()
    {
        if (isFirstActive)
        {
            amount = crystalConfig.amount;
            isFirstActive = false;

        }
        particles = GetComponent<ParticleSystem>();

    }

    public void Extract(PlayerMovimentController player){
        float exAmount = 0f;
        particles.Play();
        if(amount > 0f){
            exAmount = amount;
        }
        amount -= exAmount;
        player.CantMove(3f);
        player.AddCrystals(exAmount);
        Invoke("DisableCrystal", 3f);
    }

    private void DisableCrystal()
    {
        gameObject.SetActive(false);
    }

}
