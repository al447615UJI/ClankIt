using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private Button playButton;
    private Button settingsButton;
    private Button exitButton;
    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement container = root.Q<VisualElement>("Container");
        VisualElement bottom = container.Q<VisualElement>("Bottom");

        playButton = bottom.Q<Button>("Play");
        settingsButton = bottom.Q<Button>("Settings");
        exitButton = bottom.Q<Button>("Exit");
    }
    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Proyecto1");
    }
    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings siendo pulsado!!");
    }
    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        playButton.clicked += OnPlayButtonClicked;
        settingsButton.clicked += OnSettingsButtonClicked;
        exitButton.clicked += OnExitButtonClicked;
    }
}
