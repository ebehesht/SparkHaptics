using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextScene()
    {
        GlobalVariables.thisCircuit += 1;

        switch (GlobalVariables.thisCircuit)

        {
            case 2:
                SceneManager.LoadScene("CircuitB");
                break;
            case 3:
                SceneManager.LoadScene("CircuitC");
                break;
            case 4:
                SceneManager.LoadScene("CircuitD");
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
                SceneManager.LoadScene("CircuitB");
                break;
            case 3:
                SceneManager.LoadScene("CircuitC");
                break;

        }
    }

}
