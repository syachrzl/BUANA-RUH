using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SavePlayer(PlayerManager pm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserProgressData data = new UserProgressData(pm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UserProgressData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserProgressData data = formatter.Deserialize(stream) as UserProgressData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save File Not Found" + path);
            return null;
        }
    }

}
