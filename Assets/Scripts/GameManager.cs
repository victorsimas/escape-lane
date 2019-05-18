using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    private bool isGameStarted = false;
    private PlayerMotor motor;

    //UI and UI Fields
    public Text scoreText, coinText, modifierText;
    private float score, coinScore, modifierScore;

    private void Awake()
    {
        Instance = this;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        //UpdateScores();
    }

    private void Update()
    {
        if(MobileScript.Instance.Tap && !isGameStarted)
        {
            motor.StartRunning();
            isGameStarted = true;
        }
    }

    public void UpdateScores()
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
        modifierText.text = modifierScore.ToString();
    }
}
