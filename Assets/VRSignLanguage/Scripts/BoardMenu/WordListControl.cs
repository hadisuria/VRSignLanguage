using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordListControl : MonoBehaviour
{
    private List<GameObject> buttons;
    public void GenerateWordList(){

        buttons = new List<GameObject>();

        if(buttons.Count > 0 ){
            foreach(GameObject button in buttons){
                Destroy(button.gameObject); 
            }
            buttons.Clear();
        }

        for (int i = 0; i < SignLanguageDictionary.guideBallDataList.Count; i++) 
		{
            GameObject temp = Instantiate(Resources.Load<GameObject>("WordButton"));
            temp.SetActive(true);
            temp.GetComponentInChildren<TextMeshProUGUI>().text =  i + ". " + SignLanguageDictionary.guideBallDataList[i].word;

			temp.transform.SetParent (transform, false);
		}

    }

    public void ButtonClick(string myText){
        Debug.Log(myText);
    }
}
