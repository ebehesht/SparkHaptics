using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQuestion : MonoBehaviour {

    private Sprite taskSprite;
    SpriteRenderer taskSpriteR;

    // Use this for initialization
    void Start () {
        GameObject backButton = GameObject.Find("Back Button");

        switch (GlobalVariables.thisTask)
        {
            case 1:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task1Q");
                //deactivate the back button
                backButton.SetActive(false);
                break;
            case 2:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task2Q");
                break;
            case 3:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task3Q");
                break;
            case 4:
                taskSprite = Resources.Load<Sprite>("Sprites/Tasks/task4Q");
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
