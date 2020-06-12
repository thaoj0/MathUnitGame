using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject View;
    public GameObject aboutPanel;

    private bool menuActive = true;
    private bool aboutPanelActive = false;
    void Start()
    {
        enableViewPanel();
        Debug.Log("Application Launched");
    }

    public void gameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void gameAbout()
    {
        enableAboutPanel();
    }

    public void gameQuit()
    {
        Debug.Log("Application Exit");
        Application.Quit();
    }

    public void enableViewPanel()
    {
        disableAboutPanel();
        View.SetActive(true);
        menuActive = true;
    }

    private void disableViewPanel()
    {
        View.SetActive(false);
        menuActive = false;
    }

    private void enableAboutPanel()
    {
        disableViewPanel();
        aboutPanel.SetActive(true);
        aboutPanelActive = true;
    }

    private void disableAboutPanel()
    {
        aboutPanel.SetActive(false);
        aboutPanelActive = false;
    }
}
