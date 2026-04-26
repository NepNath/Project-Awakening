using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject optionCanva;
    [SerializeField] private GameObject mainMenuCanvas;

    void Start()
    {
        if (!optionCanva && !mainMenuCanvas)
        {
            Debug.LogError("Erreur, canva de menu non trouvé");
        }
        else
        {
            mainMenuCanvas.SetActive(true);
        }

        if (!optionCanva)
        {
            Debug.LogError("Erreur, canva d'options non trouvé");
        }
        else
        {
            optionCanva.SetActive(false);
        }
    }


    public void NewWorld()
    {
        Debug.Log("New World");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
    }

    public void OpenOptions()
    {
        optionCanva.SetActive(true);
        mainMenuCanvas.SetActive(false);
        Debug.Log("Open Options");
    }

    public void CloseOptions()
    {
        optionCanva.SetActive(false);
        mainMenuCanvas.SetActive(true);
        Debug.Log("Close Options");
    }

    public void OpenCollection()
    {
        Debug.Log("Open Collection");
    }

    public void CloseCollection()
    {
        Debug.Log("Close Collection");
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}