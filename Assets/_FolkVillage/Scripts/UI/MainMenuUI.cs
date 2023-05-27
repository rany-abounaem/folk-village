using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _controlsButton;
    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private ControlsUI _controlsUI;

    [SerializeField]
    private SceneLoader _sceneLoader;

    void Start()
    {
        _playButton.onClick.AddListener(() =>
        {
            StartCoroutine(_sceneLoader.LoadMainScene());
        });

        _controlsButton.onClick.AddListener(() =>
        {
            _controlsUI.gameObject.SetActive(true);
        });

        _exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
