using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour {
    public string menuNameScene;
    public Text coins;
    public Text station;
    public int maxCoins = 0;
    public Canvas canvas;
    public PlayerController_m player;
    public Text HScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.getRecord(station.text) < Convert.ToInt32(coins.text))
            player.setRecord(Convert.ToInt32(coins.text), station.text);
        
        HScore.text = player.getRecord(station.text).ToString();
        showUI();
    }

    public void restart()
    {
        if (station.text == "CARMES")
            SceneManager.LoadScene("Carmes");
        else if (station.text == "ESQUIROL")
            SceneManager.LoadScene("Esquirol");
        else
            SceneManager.LoadScene("Jeanne D'Arc");

    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void showUI()
    {
        canvas.gameObject.SetActive(true); //this prevents the UI element to receive input events = true;
    }

    private void hudeUI()
    {
        canvas.gameObject.SetActive(false); //this prevents the UI element to receive input events
    }
}
