using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordSectionControl : MonoBehaviour
{
    private List<GameObject> buttons;


    // generate mock data || Delete later
    private List<string> mockData = new List<string>();

    void Start(){
        // generate mock data for testing purpose
        GenerateMockData();
        GenerateWordSection();
    }

    private void GenerateMockData(){
        mockData.Add("Test 1");
        mockData.Add("Test 2");
        mockData.Add("Test 3");
        mockData.Add("Test 4");
        mockData.Add("Test 5");
    }
    //

    public void GenerateWordSection(){

        buttons = new List<GameObject>();

        if(buttons.Count > 0 ){
            foreach(GameObject button in buttons){
                Destroy(button.gameObject); 
            }
            buttons.Clear();
        }

        for (int i = 0; i < mockData.Count; i++) 
		{
            // not fixed logic & update later
            GameObject temp = Instantiate(Resources.Load<GameObject>("WordSectionButton"), transform);
            temp.SetActive(true);
            temp.GetComponentInChildren<TextMeshProUGUI>().text =  i + ". " + mockData[i];

			//temp.transform.SetParent (transform, false);
		}

    }

    public void ButtonClick(string myText){
        Debug.Log(myText);
    }

}
