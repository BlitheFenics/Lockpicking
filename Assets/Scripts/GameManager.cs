using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bar, countdown;

    private int minutes = 5, seconds = 0;
    public bool takingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetActive(false);
        countdown.SetActive(false);
        countdown.GetComponent<Text>().text = "0" + minutes + ":0" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bar.SetActive(true);
            countdown.SetActive(true);
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