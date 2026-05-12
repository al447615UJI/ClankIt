using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameplayUI ui;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        ui.UpdateScore(score);
    }

}
