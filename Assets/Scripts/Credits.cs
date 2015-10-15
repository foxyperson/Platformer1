using UnityEngine;﻿
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

    private float speed = 100f;
    public bool crawling = false;
    private Text tc;
    private string creds;


    void Start() {
        // init text here, more space to work than in the Inspector (but you could do that instead)
        tc = GetComponent<Text>();
        creds = "Well done!\n";
        creds += "You have completed Boxton!\n\n";
        creds += "Production:\nOskar Therén\n\n";
        creds += "Art Director:\nOskar Therén\n\n";
        creds += "Programming:\nOskar Therén\n\n";
        creds += "Level Design:\nOskar Therén\n\n";
        creds += "Engine: \nUnity3D\n\n";
        creds += "Music:\n";
        creds += "Random - Stiges Savepoint\n";
        creds += "\nRandom - Hux Flux Deluxe\n";
        creds += "\nRandom - Spontaneous Devotion\n\n";
        creds += "Copyright 2015 Oskar Therén";
        tc.text = creds;
    }

    void Update () {
        if (crawling) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            //if (transform.position.y > 8)
            //    crawling = false;
        }
    }
}
