using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float myLife;

    public virtual void ApplyDamage(float damage)
    {
        myLife -= damage;
        CheckDie();
    }

    public virtual void Die()
    {
        GameManager.Instance.GameOver();
    }

    private void CheckDie()
    {
        if (myLife <= 0)
        {
            Die();
        }
    }

}
