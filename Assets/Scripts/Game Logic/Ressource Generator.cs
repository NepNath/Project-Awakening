using UnityEngine;

public class RessourceGenerator : MonoBehaviour
{
    [SerializeField] private ResourceData ressource;
    
    [Header ("Generation Settings")]
    public int amountGenerated;
    
    public void GenerateForPlayer()
    {
        ressource.playerAmount += amountGenerated;
    }
    
    public void GenerateForHumans()
    {
        ressource.playerAmount += amountGenerated;
    }
}
