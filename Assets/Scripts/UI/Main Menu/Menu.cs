using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private Button playButton;
    private Button exitButton;
    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement container = root.Q<VisualElement>("Container");
        VisualElement bottom = container.Q<VisualElement>("Bottom");

        playButton = bottom.Q<Button>("Play");
        exitButton = bottom.Q<Button>("Exit");
    }
    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Proyecto1");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        playButton.clicked += OnPlayButtonClicked;
        exitButton.clicked += OnExitButtonClicked;
    }
}
