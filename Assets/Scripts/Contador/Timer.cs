using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private TMP_Text timerText;
    float elapsedTime;
    void Start()
    {
        
        timerText = GetComponent<TMP_Text>();
    }  
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime; 
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
