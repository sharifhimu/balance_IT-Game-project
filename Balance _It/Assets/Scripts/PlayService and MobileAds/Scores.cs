using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Scores : MonoBehaviour {

	private static Scores instance;

	public static Scores Instance
	{
		get
		{
			return instance;
		}
	}

    public Records records;
    public Settings settings;
    

    public void SaveData()
    {
        PPSerialization.Save("High", records);
    }

    public void SaveRecordBinaryData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/CircleGameRecords.hehe";
        FileStream stream = new FileStream(path, FileMode.Create);

      //  DataToSave data = new DataToSave(records);

        formatter.Serialize(stream, records);

        stream.Close();
    }

    public void SaveSettingsBinaryData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/CircleGameSettings.hehe";
        FileStream stream = new FileStream(path, FileMode.Create);

        //  DataToSave data = new DataToSave(records);

        formatter.Serialize(stream, settings);

        stream.Close();
    }

    //public void SavetoCloud()
    //{
    //    SaveBinaryData();
    //    if (Application.internetReachability != NetworkReachability.NotReachable)
    //        PlayServiceMangerWithCloudSave.instance.SaveToCloud(records);

    //}


    public Records LoadData()
	{
		object x = (Records)PPSerialization.Load ("circleGameRecords");
		if (x != null)
			return (Records)x;
		else
			return null;
	}

    public Records LoadRecordFromBinaryData()
    {
        string path = Application.persistentDataPath + "/CircleGameRecords.hehe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Records data = formatter.Deserialize(stream) as Records;

            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public Settings LoadSettingsFromBinaryData()
    {
        string path = Application.persistentDataPath + "/CircleGameSettings.hehe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Settings data = formatter.Deserialize(stream) as Settings;

            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    //public Records LoadFromCloud()
    //{
    //    Records y = (Application.internetReachability != NetworkReachability.NotReachable) ? PlayServiceMangerWithCloudSave.instance.LoadFromCloud() : null;
    //    Records x = LoadFromBinaryData();
    //    if(y != null )
    //    {
    //        return (y.highScore < x.highScore) ? x : y;
    //    }
    //    return x;
    //}

    // Use this for initialization
    void Start () {
		instance = this;
        //PlayerPrefs.DeleteAll ();
        //ClearBinaryData();
		DontDestroyOnLoad (gameObject);	

		Records tmprecord = LoadRecordFromBinaryData ();
        Settings tmpSetting = LoadSettingsFromBinaryData();
		if(tmprecord == null)
        {
            // do something on default
            records.currentLevelIndex = 1;
            records.rank = 0;
            records.highScore = 0;
            records.totalScore = 0;
            records.is_sound_Active = true;
            instance.SaveRecordBinaryData();
           

        }
        else
        {
            records = tmprecord;
            
        }

        if (tmpSetting == null)
        {
            settings.levels[0].isUnlocked = true;
            settings.levels[0].highscore = 0;
            settings.ballUnlocked[0] = true;
            
            for (int i = 1; i < settings.levels.Length; i++)
            {
                settings.levels[i].isUnlocked = false;
                settings.levels[i].highscore = 0;
            }
            for (int i = 1; i < settings.ballUnlocked.Length; i++)
                settings.ballUnlocked[i] = false;


            instance.SaveSettingsBinaryData();
        }
        else
        {
            settings = tmpSetting;
        }
	}


    private void ClearBinaryData()
    {
        string pathrec = Application.persistentDataPath + "/CircleGameRecords.hehe";
        string pathsetting = Application.persistentDataPath + "/CircleGameSettings.hehe";
        if (File.Exists(pathrec))
        {
            File.Delete(pathrec);
        }

        if (File.Exists(pathsetting))
        {
            File.Delete(pathsetting);
        }
    }

}

[System.Serializable]
public class Records
{
    public int highScore;
    public int rank;
    public int coin;
    public int currentLevelIndex;
    public int totalScore;
    public bool is_sound_Active;
}

[System.Serializable] public class Settings
{
    public LevelInfo[] levels;
    public bool[] ballUnlocked;
    public bool newLevelUnlock;
    public int ballIndx;
} 

[System.Serializable]
public class LevelInfo
{
    public int highscore;
    public bool isUnlocked;
}