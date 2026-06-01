using UnityEngine;
using TMPro;

public class GeneratorButton : MonoBehaviour
{
    [SerializeField] private ResourceData resource;
    [SerializeField] private TMP_Text label;

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

        label.text = $"Generate {resource.displayName}";
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
