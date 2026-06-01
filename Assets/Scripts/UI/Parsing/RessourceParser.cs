using UnityEngine;
using TMPro;

public class RessourceParser : MonoBehaviour
{
    [SerializeField] private ResourceData resource;
    [SerializeField] private TMP_Text label;
    [SerializeField] private ResourceOwner displayedOwner;
    
    
    private void Reset()
    {
        // Auto-assigne le TMP présent sur le même GameObject
        label = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (resource != null)
        {
            resource.Changed += Refresh;
        }
        Refresh();
    }
    private void OnDisable()
    {
        if (resource != null)
        {
            resource.Changed -= Refresh;
        }
    }

    public void Refresh()
    {
        if (label == null)
        {
            label = GetComponent<TMP_Text>();
        }

        if (resource == null)
        {
            label.text =  "no ressource assigned, please assign one";
            return;
        }

        label.text = $"{resource.displayName} : {resource.GetAmount(displayedOwner)}";
    }

#if UNITY_EDITOR
    private void OnValidate()
    {

        if (label == null)
        {
            label = GetComponent<TMP_Text>();
        }
        
        Refresh();
    }
#endif
}
