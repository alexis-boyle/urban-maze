using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MazeUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI content;
    [SerializeField] GameObject end;
    [SerializeField] Game game;

    private float timeVal;
    private string timerString;
    private bool timeStarted;

    public void InitGUI()
    {
        timeVal = 0;
        timeStarted = true;
        timer.gameObject.SetActive(true);
        end.SetActive(false);
    }


    public void UpdateTimer()
    {
        if(timeStarted)
        {
            timeVal += Time.deltaTime;
            timer.text = timeToString(timeVal);
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturntoMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturntoMenu();
        }
    }

    public void EndMaze()
    {
        end.SetActive(true);
        timeStarted = false;
        content.text = "Total Time: " + timeToString(timeVal) + 
            "\nPlayMode: " + game.playThrough;
    }

    private string timeToString(float time)
    {
        float minutes = Mathf.Floor(timeVal / 60);
        float seconds = Mathf.RoundToInt(timeVal % 60);
        string min = minutes.ToString();
        string sec = seconds.ToString();

        if (minutes < 10)
        {
            min = "0" + minutes.ToString();
        }
        if (seconds < 10)
        {
            sec = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        return min + ":" + sec;
    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
