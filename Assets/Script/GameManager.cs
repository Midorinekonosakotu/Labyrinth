using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        GameState.Instance.SetState(GameState.State.Playing);
        SceneManager.LoadScene("MainGame");
    }

    public void GoToTitle()
    {
        GameState.Instance.SetState(GameState.State.Title);
        SceneManager.LoadScene("Title");
    }

    public void GoToResult()
    {
        SceneManager.LoadScene("Result");
    }
}