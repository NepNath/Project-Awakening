using UnityEngine;
using System.Collections.Generic;


public class GameOrchestrator : MonoBehaviour
{
    [SerializeField] private bool resetAllOnStart = false;

    [Header("Resources")] [SerializeField]
    private List<ResourceData> resources;

    void Start()
    {
        if (resetAllOnStart)
        {
            ResetAllRessources();
        }
    }

    public void ResetPlayerRessources()
    {
        foreach (var r in resources)
        {
            r.playerAmount = 0;
        }
    }

    public void ResetHumanRessources()
    {
        foreach (var r in resources)
        {
            r.humanAmount = 0;
        }
    }

    public void ResetAllRessources()
    {
        foreach (var r in resources)
        {
            r.playerAmount = 0;
        }

        foreach (var r in resources)
        {
            r.humanAmount = 0;
        }
    }
}