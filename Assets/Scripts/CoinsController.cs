﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour {

    public Text coinValue;
    public int valueCoin;
    private bool colEnter = false;
    private AudioSource source;
    private int currentCoin = 0;
    public PlayerController_m player;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (colEnter == true)
            return;
        colEnter = true;
        currentCoin = Convert.ToInt32(coinValue.text) + valueCoin;
        coinValue.text = currentCoin.ToString();
        source.Play();
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update () {
		
    }

    public int getCoins()
    {
        return (currentCoin);
    }
}
