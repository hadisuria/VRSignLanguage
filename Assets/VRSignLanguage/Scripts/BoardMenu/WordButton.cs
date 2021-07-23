﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(ButtonEvent))]
public class WordButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myString;
    private ButtonEvent buttonEvent;
    private GuideBall myGuideBall;
    //private string myTextString;
    private BoardMenuController menuController;

    private void Awake() {
        buttonEvent = GetComponent<ButtonEvent>();
        buttonEvent.OnButtonClicked += OnWordClicked;
        menuController = FindObjectOfType<BoardMenuController>();
    }

    public void Init(GuideBall value)
    {
        SetText(value.word);
        myGuideBall = value;
    }

    public void SetText(string textString){
        //myTextString = textString;
        myString.text = textString;
    }

    public void OnWordClicked(){
        //wordListControl.ButtonClick(myTextString);
        menuController.OpenMenu(BoardMenuID.SignLanguagePreview, myGuideBall);
        Debug.Log("Show Word : " + $"{myGuideBall.word}");
    }
}
