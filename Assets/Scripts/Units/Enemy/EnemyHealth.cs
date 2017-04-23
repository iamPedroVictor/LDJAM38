using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    public float value;

    public override void Die()
    {
        GameManager.Instance.AddPoint(value);
        Destroy(this.gameObject);
    }

}
