﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ButtonEvent))]
public class WordSectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myString;
	private ButtonEvent button;
    //private List<GuideBall> section = new List<GuideBall>();
    private int section;
	private SectionData mySection = new SectionData();

	private BoardMenuController menuController;

	private void Awake()
	{
		button = GetComponent<ButtonEvent>();
		button.OnButtonClicked += Button_OnButtonClicked;
		menuController = FindObjectOfType<BoardMenuController>();
	}

	public void Init(List<GuideBall> targetValue, string text)
	{
		SetText(text);
		SetSection(targetValue);
	}

	private void Button_OnButtonClicked()
	{
		menuController.OpenMenu(BoardMenuID.MultipleChoices, mySection);
	}

	private void SetText(string textString){
        myString.text = textString;
    }

    private void SetSection(List<GuideBall> value)
	{
		mySection.sectionWordList = value;
        //section = value;
		Debug.Log("section count : " + value.Count + " ===== " + mySection.sectionWordList.Count);
	}
}
