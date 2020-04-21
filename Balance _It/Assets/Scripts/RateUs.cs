using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;


[System.Serializable]
public class RateUs : MonoBehaviour {

    private static RateUs instance;

    public static RateUs Instance
    {
        get
        {
            return instance;
        }
    }

    public RateInfo rateInfo;

	// Use this for initialization
	void Start () {
        instance = this;
        DontDestroyOnLoad(gameObject);
        //ClearRateInfoBinaryData();

        RateInfo tmp = LoadRateInfoFromBinaryData();

        if(tmp==null)
        {
            rateInfo.count++;
            rateInfo.is_Rated = false;
            instance.SaveRateInfoBinaryData();
        }
        else
        {
            rateInfo = tmp;
            rateInfo.count++;
            instance.SaveRateInfoBinaryData();
        }

       
    }
	


    public void SaveRateInfoBinaryData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/CircleGameRateInfo.hehe";
        FileStream stream = new FileStream(path, FileMode.Create);

        //  DataToSave data = new DataToSave(records);

        formatter.Serialize(stream, rateInfo);

        stream.Close();
    }


    public RateInfo LoadRateInfoFromBinaryData()
    {
        string path = Application.persistentDataPath + "/CircleGameRateInfo.hehe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RateInfo info = formatter.Deserialize(stream) as RateInfo;

            stream.Close();
            return info;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    private void ClearRateInfoBinaryData()
    {
        string path = Application.persistentDataPath + "/CircleGameRateInfo.hehe";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    [System.Serializable]
    public class RateInfo
    {
        public int count;
        public bool is_Rated;
    }
}
