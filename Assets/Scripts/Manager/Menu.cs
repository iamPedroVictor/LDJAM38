using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject MenuPanel, PlayPanel, CreditsPanel;

    public void Start()
    {
        MenuPanel.SetActive(true);
        PlayPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void GoMenu()
    {
        MenuPanel.SetActive(true);
        PlayPanel.SetActive(false);
        CreditsPanel.SetActive(false);

    }

    public void GoPlay()
    {
        MenuPanel.SetActive(false);
        PlayPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        Invoke("History", 1f);
        if (Input.anyKeyDown)
        {
            History();
        }
    }

    public void GoCredits()
    {
        MenuPanel.SetActive(false);
        PlayPanel.SetActive(false);
        CreditsPanel.SetActive(true);

    }

    public void History()
    {
        CancelInvoke("History");
        SceneManager.LoadScene("Game");
    }

}
