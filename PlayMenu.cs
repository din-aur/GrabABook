using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("Gameplay",LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        // Debug.Log("COOKEEEED!");
        SonicManager.instance.PlaySound("Clicked");
        Application.Quit();
    }
    public void HowTo()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("HowToPlay",LoadSceneMode.Single);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SonicManager.instance.PlaySound("Clicked");
        SceneManager.LoadScene("PlayMenu",LoadSceneMode.Single);
    }
}
