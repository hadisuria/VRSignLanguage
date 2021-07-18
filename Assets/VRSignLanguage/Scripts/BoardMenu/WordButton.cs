using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myString;
    [SerializeField] private WordListControl wordListControl;

    private string myTextString; 
    // Start is called before the first frame update
    public void SetText(string textString){
        myTextString = textString;
        myString.text = textString;
    }

    public void onClickWord(){
        wordListControl.ButtonClick(myTextString);
    }
}
