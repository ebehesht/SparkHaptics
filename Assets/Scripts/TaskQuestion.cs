using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQuestion : MonoBehaviour {

    private Sprite taskSprite;
    SpriteRenderer taskSpriteR;

    PlayerLog thisPlayerLog;

    // Use this for initialization
    void Start () {

        thisPlayerLog = GameObject.Find("EventSystem").GetComponent<PlayerLog>();

        GameObject backButton = GameObject.Find("Back Button");

        switch (GlobalVariables.thisTask)
        {
            case 1:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task1Q");
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Start Question 1");
                //deactivate the back button
                backButton.SetActive(false);
                break;
            case 2:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task2Q");
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Start Question 2");
                break;
            case 3:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task3Q");
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Start Question 3");
                break;
            case 4:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task4Q");
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Start Question 4");
                break;
            case 5:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task5Q");
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Start Question 5");
                break;
        }

        GameObject taskQ = GameObject.Find("Task Question");
        taskSpriteR = taskQ.GetComponent<SpriteRenderer>();
        taskSpriteR.sprite = taskSprite;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
