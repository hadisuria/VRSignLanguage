using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    // CONSTANT FOR SAVE FILE
    public static readonly string SAVE_CALIBRATION = "SavedCalibration.json";
    public static readonly string SAVE_SIGN_LANGUAGE_DICTIONARY = "SavedSignLanguageDictionary.json";

    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init()
	{
        // check if save folder exist 
        if (!Directory.Exists(SAVE_FOLDER)) {
            // create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        } 
	}

    public static void SaveData(string saveString, string fileName)
    {
        File.WriteAllText(SAVE_FOLDER + fileName, saveString);
    }


    /**
     * @param {string} fileName - expected filename to load
     */

    public static string LoadData(string fileName)
    {
        if (File.Exists(SAVE_FOLDER + fileName))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + fileName);
            return saveString;
        } else
		{
            return null;
		}
    }
}
