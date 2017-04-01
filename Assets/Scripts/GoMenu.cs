using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour {
    public string menuNameScene;
    public Text coins;
    public int maxCoins = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Convert.ToInt32(coins.text) == maxCoins)
        {
            SceneManager.LoadScene(menuNameScene, LoadSceneMode.Single);
        }
        else if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
