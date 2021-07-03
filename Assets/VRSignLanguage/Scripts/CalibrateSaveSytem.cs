using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CalibrateSaveSytem
{

    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init()
	{
        // check if save folder exist 
        if (!Directory.Exists(SAVE_FOLDER)) {
            // create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        } 
	}

    public static void SaveCalibratedData(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "/SavedCalibration.txt", saveString);

    }

    public static string LoadCalibratedData()
    {
        if (File.Exists(SAVE_FOLDER + "/SavedCalibration.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/SavedCalibration.txt");
            return saveString;
        } else
		{
            return null;
		}
    }
}
