using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class EndOfGame : MonoBehaviour
{
    [SerializeField]
    private Player _player;
 
    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Button _exitButton;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDiedPlayer;

        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDiedPlayer;

        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();

        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;

        Time.timeScale = 1f;
    }

    private void OnDiedPlayer()
    {
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;

        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}