﻿using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        //Aボタンをクリック
        if (Input.GetKeyDown("joystick button 0"))
        {
            Application.LoadLevel("mainScene2");
        }
        //Bボタンをクリック
        if (Input.GetKeyDown("joystick button 1"))
        {
            Application.LoadLevel("mainScene2");
        }

        //Xボタンをクリック
        if (Input.GetKeyDown("joystick button 2"))
        {
            Application.LoadLevel("mainScene2");
        }

        //Yボタンをクリック
        if (Input.GetKeyDown("joystick button 3"))
        {
            Application.LoadLevel("mainScene2");
        }
        
        //Startボタンをクリック
        if (Input.GetKeyDown("joystick button 7"))
        {
            Application.LoadLevel("mainScene2");
        }


	}
}
