using UnityEngine;
using Tools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(PlayerData playerData, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + fileName + ".mt";
        //var content = JsonUtility.ToJson(playerData, true);
        //File.WriteAllText(path, content);
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, playerData);
        stream.Close();
        
    }

    public static void SaveUserInfo(UserInfo userInfo, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + fileName + ".mtif";
        //var content = JsonUtility.ToJson(playerData, true);
        //File.WriteAllText(path, content);
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, userInfo);
        stream.Close();
        
    }

    public static PlayerData Load(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".mt";
        if(File.Exists(path))
        {
            //var content = File.ReadAllText(path);
			//playerData = JsonUtility.FromJson<PlayerData>(content);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return playerData;
        }
        else
        {
            Debug.LogWarning("File not exists");
            return null;
        }
    }

    public static UserInfo LoadUserInfo(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".mtif";
        if(File.Exists(path))
        {
            //var content = File.ReadAllText(path);
			//playerData = JsonUtility.FromJson<PlayerData>(content);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            UserInfo userInfo = formatter.Deserialize(stream) as UserInfo;
            stream.Close();
            return userInfo;
        }
        else
        {
            Debug.LogWarning("File not exists");
            return new UserInfo();
        }
    }

}