using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public List<PersistantObject> ObjectsToSave;

    public void OnEnable()
    {
        foreach (PersistantObject score in ObjectsToSave) { 
            score.Load();
        }
    }
    public void OnDisable()
    {
        foreach(PersistantObject score in ObjectsToSave)
        {
            score.Save();
        }
    }
}
