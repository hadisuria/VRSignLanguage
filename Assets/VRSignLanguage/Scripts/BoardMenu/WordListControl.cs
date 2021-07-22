using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class WordListControl : MonoBehaviour
{
    private List<WordButton> buttons = new List<WordButton>();
    [SerializeField]
    private GameManager gameManager;

    public void GenerateWordList(){

        //test debug
        Reset();
        Debug.Log("(Generating WordList) Game manager" + gameManager.languageDictionary.guideBallDataList.Count);

        for (int i = 0; i < gameManager.languageDictionary.guideBallDataList.Count; i++) 
		{
            WordButton temp = Instantiate(Resources.Load<GameObject>("WordButton"), transform).GetComponent<WordButton>();
            temp.gameObject.SetActive(true);
            // if(temp.TryGetComponent<ButtonEvent>(out ButtonEvent target))
            // {
            //     target.OnButtonClicked += ShowWordDetail();
            // }
            // temp.GetComponentInChildren<TextMeshProUGUI>().text =  (i+1) + ". " + gameManager.languageDictionary.guideBallDataList[i].word;
			// temp.transform.SetParent (transform, false);
            temp.Init(gameManager.languageDictionary.guideBallDataList[i]);

            buttons.Add(temp);
		}

    }

    private void ShowWordDetail()
    {
        Debug.Log("Showing Word Detail Here. . .");
    }

    public void ButtonClick(string myText){
        Debug.Log(myText);
    }

    private void Reset(){
        if(buttons.Count > 0 ){
            foreach(WordButton button in buttons){
                Destroy(button.gameObject); 
            }
            buttons.Clear();
        }
    }

    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        GenerateWordList();
    }
}
