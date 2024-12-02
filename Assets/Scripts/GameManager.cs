using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _continueButton;

    public bool _isPlaying = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        _isPlaying = true;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        _stopButton.SetActive(false);
        _continueButton.SetActive(false);
        _isPlaying = false;

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StopGame()
    {
        _continueButton.SetActive(true);
        _stopButton.SetActive(false);
        _isPlaying = false;
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        _continueButton.SetActive(false);
        _stopButton.SetActive(true);
        _isPlaying = true;
        Time.timeScale = 1f;
    }
}
