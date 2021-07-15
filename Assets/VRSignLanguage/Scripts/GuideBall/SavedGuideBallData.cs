using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedGuideBallData : MonoBehaviour
{
    /* 
     * ---REPRESENTATION OF DATA TO BE USED IN GUIDEBALL MOVEMENT---
	 * ---guidball---
	 * SavedGuideBallData = 
     * [
	 *  {
	 *	 word: "hello"
	 *	 left: [Vector3, Vector3, Vector3,]
	 *	 right: [ Vector3 ]
     *  },
     *  {
	 *	 word: "What"
	 *	 left: [Vector3, Vector3, Vector3,]
	 *	 right: [ Vector3 ]
     *  },
	 * ];
     */

    // private List<GuideBall> SavedGuideBallData = new List<GuideBall>();

    // private void SaveData(SavedGuideBallData savedGuideBallDataObj)
	// {
	// 	string json = JsonUtility.ToJson(savedGuideBallDataObj);
	// 	SaveSystem.SaveData(json, SaveSystem.SAVE_GUIDEBALL_DATA);
	// }

	// private void LoadData()
	// {
	// 	// load the guideball data if any
	// 	string saveString = SaveSystem.LoadData(SaveSystem.SAVE_GUIDEBALL_DATA);
	// 	if(saveString != null)
	// 	{
	// 		SavedGuideBallData savedGuideBallDataObj = JsonUtility.FromJson<SavedGuideBallData>(saveString);
    //         SavedGuideBallData.Add(savedGuideBallDataObj);
	// 	}
	// }

	// public SavedGuideBallData(List<GuideBall> savedGuideBallData)
	// {
	// 	this.SavedGuideBallData = savedGuideBallData;
	// }
}
