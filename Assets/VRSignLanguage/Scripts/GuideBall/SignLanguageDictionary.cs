using System.Collections.Generic;
using UnityEngine;

public class SignLanguageDictionary
{
	/* 
     * ---REPRESENTATION OF DATA TO BE USED IN GUIDEBALL MOVEMENT---
	 * ---guidball---
	 * guideBallDataList = 
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

	public static List<GuideBall> guideBallDataList { get; private set; } = new List<GuideBall>();

	private void SaveData(List<GuideBall> savedGuideBallData)
	{
		string json = JsonUtility.ToJson(savedGuideBallData);
		SaveSystem.SaveData(json, SaveSystem.SAVE_SIGN_LANGUAGE_DICTIONARY);
	}

	private void LoadData()
	{
		// load the guideball data if any
		string saveString = SaveSystem.LoadData(SaveSystem.SAVE_SIGN_LANGUAGE_DICTIONARY);
		if (saveString != null)
		{
			List<GuideBall> savedGuideBallDataObj = JsonUtility.FromJson<List<GuideBall>>(saveString);
			guideBallDataList = savedGuideBallDataObj;
		}
	}

	public void AddWord(GuideBall newGuideBall)
	{
		
		guideBallDataList.Add(newGuideBall);
		// Savedata
		SaveData(guideBallDataList);
	}

	//public SignLanguageDictionary(List<GuideBall> savedGuideBallData)
	//{
	//	this.guideBallDataList = savedGuideBallData;
	//}
}
