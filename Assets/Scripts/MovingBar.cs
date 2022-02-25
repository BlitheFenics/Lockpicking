using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBar : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float Speed;

    private Vector3 startingPosition;
    private int unlocked = 0;

    // Start is called before the first frame update
    void Awake()
    {
        startingPosition = transform.position;
        int difficulty = Random.Range(1, 4);
        if (difficulty == 1)
        {
            Speed = 0.5f;
        }
        if (difficulty == 2)
        {
            Speed = 1f;
        }
        if (difficulty == 3)
        {
            Speed = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.activeSelf);
        if(gameObject.activeSelf == true)
        {
            //Debug.Log(Speed);
            Vector3 v = startingPosition;
            v.x = distanceToCover * Mathf.Sin(Time.time * Speed);
            transform.position = v;

            Spacebar();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "UnlockBar")
        {
            unlocked = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        unlocked = 2;
    }

    public void Spacebar()
    {
        if(unlocked == 1)
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed inside green bar");
            }
        }

        if(unlocked == 2)
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed outside green bar");
            }
        }
    }
}