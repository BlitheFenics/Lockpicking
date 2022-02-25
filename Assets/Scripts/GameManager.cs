using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bar, countdown, difficulty, begin, lose;

    private int minutes = 5, seconds = 0;
    public bool takingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetActive(false);
        begin.SetActive(true);
        lose.SetActive(false);
        difficulty.SetActive(false);
        countdown.SetActive(false);
        countdown.GetComponent<Text>().text = "0" + minutes + ":0" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lose.activeSelf == false)
        {
            bar.SetActive(true);
            begin.SetActive(false);
            difficulty.SetActive(true);
            countdown.SetActive(true);
            lose.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && lose.activeSelf == true)
        {
            SceneManager.LoadScene(0);
        }

        if(bar.activeSelf == true)
        {
            if(takingAway == false)
            {
                StartCoroutine(Timer());
            }
        }
    }

    IEnumerator Timer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        seconds -= 1;

        if (seconds <= 0)
        {
            minutes -= 1;
            seconds = 59;
        }
        if(minutes < 0)
        {
            minutes = 5;
            seconds = 0;

            bar.SetActive(false);
            begin.SetActive(false);
            difficulty.SetActive(false);
            countdown.SetActive(false);
            lose.SetActive(true);
        }

        if (seconds < 10 && minutes >= 10)
        {
            countdown.GetComponent<Text>().text = minutes + ":0" + seconds;
        }
        if(minutes < 10 && seconds >= 10 || minutes < 10 && seconds < 0)
        {
            countdown.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
        }
        if(minutes < 10 && seconds < 10)
        {
            countdown.GetComponent<Text>().text = "0" + minutes + ":0" + seconds;
        }
        else
        {
            countdown.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
        }
        
        takingAway = false;
    }
}