using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public abstract class PersistantScore : ScriptableObject
{
    public void Save(string FileName = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(GetPath(FileName));
        var json = JsonUtility.ToJson(this);

        bf.Serialize(file, json);
        file.Close();
    }

    public virtual void Load(string FileName = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Open(GetPath(FileName), FileMode.Open);
        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),this);
        file.Close();
    }

    private string GetPath(string FileName = null) 
    { 
        var fullFileName = string.IsNullOrEmpty(FileName) ? name : FileName;
        return string.Format("{0}/{1}.sv", Application.persistentDataPath, fullFileName);
    }
}
