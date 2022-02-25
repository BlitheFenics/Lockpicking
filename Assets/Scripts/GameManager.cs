using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bar.activeSelf);
        if (Input.GetKeyDown(KeyCode.E))
        {
            bar.SetActive(true);
        }
    }
}