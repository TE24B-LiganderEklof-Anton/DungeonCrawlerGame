using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour//handles the ui in the StartMenu scene
{

    GameObject tutorialPanel;

    void Start()
    {
        tutorialPanel = transform.Find("TutorialPanel").gameObject;
    }
    public void ToggleTutorial()//hides/shows tutorial panel
    {
        tutorialPanel.SetActive(!tutorialPanel.activeInHierarchy);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
