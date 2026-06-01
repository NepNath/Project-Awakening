using UnityEngine;

public class RessourceGenerator : MonoBehaviour
{
    [SerializeField] private ResourceData ressource;
    
    [Header ("Generation Settings")]
    public int amountGenerated;
    [SerializeField] private ResourceOwner GenerateFor;
    public void GenerateRessources()
    {
        ressource.AddAmount(GenerateFor, amountGenerated);
    }
}
