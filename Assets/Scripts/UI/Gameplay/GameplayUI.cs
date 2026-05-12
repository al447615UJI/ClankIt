using UnityEngine;
using UnityEngine.UIElements;

public class GameplayUI : MonoBehaviour
{

    [SerializeField] private string scoreText = "Score: ";
    private Label timer;
    private Label score;
    private float elapsedTime;


    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement container = root.Q<VisualElement>("Container");
        VisualElement up = container.Q<VisualElement>("Up");
        timer = up.Q<Label>("Timer");
        score = up.Q<Label>("Score");
    }

    void Update()
    {
        Count();
    }


    private void Count()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateScore(int newScore)
    {
        score.text = scoreText + newScore;
    }
}
