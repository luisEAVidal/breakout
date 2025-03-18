using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public List<PersistantScore> ObjectsToSave;

    public void OnEnable()
    {
        foreach (PersistantScore score in ObjectsToSave) { 
            score.Load();
        }
    }
    public void OnDisable()
    {
        foreach(PersistantScore score in ObjectsToSave)
        {
            score.Save();
        }
    }
}
