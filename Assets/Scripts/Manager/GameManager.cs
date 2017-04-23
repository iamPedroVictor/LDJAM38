using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private static GameManager _instance;

    private float playerPoint;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        playerPoint = 0;
        
    }

    public void AddPoint(float value)
    {
        playerPoint += value;
    }

    public void GameOver()
    {

    }

}
