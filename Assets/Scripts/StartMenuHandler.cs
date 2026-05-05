using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{
   
    GameObject tutorialPanel;

    void Start()
    {
        tutorialPanel = transform.Find("TutorialPanel").gameObject;
    }
    public void ToggleTutorial()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeInHierarchy);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
