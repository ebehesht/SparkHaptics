using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {

        Debug.Log("starting executing button script");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        GlobalVariables.thisCircuit += 1;

        switch (GlobalVariables.thisCircuit)

        {
            case 2:
                SceneManager.LoadScene("CircuitA Options");
                break;
            case 3:
                SceneManager.LoadScene("CircuitA Strength");
                break;
            case 4:
                SceneManager.LoadScene("CircuitA Strength V2");
                break;
            case 5:
                SceneManager.LoadScene("CircuitA Texture");
                break;
        }
    }

    public void PrevScene()
    {
        GlobalVariables.thisCircuit -= 1;

        switch (GlobalVariables.thisCircuit)

        {
            case 1:
                SceneManager.LoadScene("CircuitA");
                break;
            case 2:
                SceneManager.LoadScene("CircuitA Options");
                break;
            case 3:
                SceneManager.LoadScene("CircuitA Strength");
                break;
            case 4:
                SceneManager.LoadScene("CircuitA Strength V2");
                break;
        }
    }

    public void NextPage(string thisPage)
    {
        //Debug.Log(GlobalVariables.thisCircuit);
        


        if (thisPage == "question")
        {
            SceneManager.LoadScene("Task Explore");
        }
        else
        {
            GlobalVariables.thisTask += 1;
            SceneManager.LoadScene("Task Question");
        }

    }

    public void PrevPage(string thisPage)
    {
        //Debug.Log(GlobalVariables.thisCircuit);



        if (thisPage == "question")
        {
            GlobalVariables.thisTask -= 1;
            SceneManager.LoadScene("Task Explore");
        }
        else
        {            
            SceneManager.LoadScene("Task Question");
        }

    }


}
