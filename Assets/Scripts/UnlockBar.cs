using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBar : MonoBehaviour
{
    [SerializeField] GameObject PlayerSkill;

    private int playerSkill = 0;

    private int highlighted = 0;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerSkill.GetComponent<Text>().text = "Player Skill: " + playerSkill;
    }

    // Update is called once per frame
    void Update()
    {
        Spacebar();
    }

    public void Spacebar()
    {
        if (highlighted == 1)
        {
            if (Input.GetKeyDown("space") && gameObject.transform.localScale.y < 1)
            {
                playerSkill += 1;
                PlayerSkill.GetComponent<Text>().text = "Player Skill: " + playerSkill;
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y + 0.01f, gameObject.transform.localScale.z);
            }
        }

        if (highlighted == 2)
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed outside green bar");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MovingBar")
        {
            highlighted = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        highlighted = 2;
    }
}