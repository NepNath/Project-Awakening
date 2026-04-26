using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdownBehavior : MonoBehaviour
{
    
    public TMP_Dropdown dropdown;
    public Toggle fullScreenToggle;
    
    private Resolution[] _allResolutions;
    private bool _isFullScreen;
    private int _selectedResolution;
    
    void Start()
    {
        _isFullScreen = Screen.fullScreen;
        _allResolutions = Screen.resolutions;
        
        List<string> resolutionStringList = new List<string>();

        foreach (Resolution resolution in _allResolutions)
        {
            resolutionStringList.Add(resolution.ToString());
        }
        
        dropdown.AddOptions(resolutionStringList);
    }
}
