using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public enum ResourceOwner
{
    Player,
    Human,
    All
}

[CreateAssetMenu(fileName = "RessourceData", menuName = "Scriptable Objects/Ressource")]
public class ResourceData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    [SerializeField] private int _playerAmount;
    [SerializeField] private int _humanAmount;
    public event System.Action Changed; 
    
    public int playerAmount
    {
        get => _playerAmount;
        set
        {
            if (_playerAmount == value)
            {
                return;
            }

            _playerAmount = value;
            Changed?.Invoke();
        }
    }
    public int humanAmount
    {
        get => _humanAmount;
        set
        {
            if (_humanAmount == value)
            {
                return;
            }

            _humanAmount = value;
            Changed?.Invoke();
        }
    }
    
    public int GetAmount(ResourceOwner owner)
    {
        switch (owner)
        {
            case ResourceOwner.Player:
                return playerAmount;
            case ResourceOwner.Human:
                return humanAmount;
            case ResourceOwner.All:
                return humanAmount + playerAmount;
            default:
                return 0;
        }
    }

    public int AddAmount(ResourceOwner target, int amount)
    {
        switch (target)
        {
            case ResourceOwner.Player:
                return playerAmount += amount;
            case ResourceOwner.Human:
                return humanAmount += amount;
            case ResourceOwner.All:
                return (humanAmount + playerAmount) + amount ;
            default:
                return 0;
        }
    }
    
    
}
