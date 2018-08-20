using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int thisCircuit = 1; //not really using it
    public static int thisTask = 1;
    public static int RGlobal = 1;
    public static bool formative = false; // this is for the code for the formative study
    public static bool hapticOn = true;
}

public class Circuit : MonoBehaviour {

    private HapticSquare haptic;
    private string currentHapticType;

    private GameObject hint;

    private Sprite circuitSprite1;
    private Sprite circuitSprite2;
    private Sprite circuitSprite3;

    private Sprite taskSprite;

    GameObject nextButton;
    GameObject buttonC1;
    GameObject buttonC2;
    GameObject buttonC3;

    SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {

        if (GlobalVariables.formative) StartFormative();
        else
        {
            hint = GameObject.Find("Hint");
            hint.SetActive(false);

            Debug.Log("this circuit: " + GlobalVariables.thisTask);
            haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();

            nextButton = GameObject.Find("Next Button");
            buttonC1 = GameObject.Find("Circuit1 Button");
            buttonC2 = GameObject.Find("Circuit2 Button");
            buttonC3 = GameObject.Find("Circuit3 Button");

            buttonC1.SetActive(false);
            buttonC2.SetActive(false);
            buttonC3.SetActive(false);

            switch (GlobalVariables.thisTask)
            {
                case 1:
                    circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1"); 
                    taskSprite = Resources.Load<Sprite>("Sprites/Buttons/taskA");
                    currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                    haptic.UpdateHaptics(currentHapticType);
                    break;
                case 2:
                    circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit2");
                    taskSprite = Resources.Load<Sprite>("Sprites/Buttons/taskB");
                    currentHapticType = HapticSquare.HapticType.STRIPEMED2;
                    haptic.UpdateHaptics(currentHapticType);
                    break;
                case 3:
                    circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1");
                    taskSprite = Resources.Load<Sprite>("Sprites/Buttons/taskC");
                    currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                    haptic.UpdateHaptics(currentHapticType);

                    //activate C1 and C2 buttons
                    buttonC1.SetActive(true);
                    buttonC2.SetActive(true);

                    break;
                case 4:
                    circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1");
                    taskSprite = Resources.Load<Sprite>("Sprites/Buttons/taskD");
                    currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                    haptic.UpdateHaptics(currentHapticType);

                    //activate C1 and C2 buttons
                    buttonC1.SetActive(true);
                    buttonC2.SetActive(true);
                    buttonC3.SetActive(true);

                    //deactivate the back button
                    nextButton.SetActive(false);
                    break;
            }

            haptic.DeactivateHaptic();

            GameObject circuit = GameObject.Find("Circuit");
            spriteR = circuit.GetComponent<SpriteRenderer>();
            spriteR.sprite = circuitSprite1;

            GameObject taskLabel = GameObject.Find("Task Label");
            spriteR = taskLabel.GetComponent<SpriteRenderer>();
            spriteR.sprite = taskSprite;

        }


    }

    private void StartFormative()
    {
        Debug.Log("start circuit.cs for formative");
        // circuits for testing different circuits with high, med, low current
        circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuitA");
        circuitSprite2 = Resources.Load<Sprite>("Sprites/Circuits/circuitA2");
        circuitSprite3 = Resources.Load<Sprite>("Sprites/Circuits/circuitA3");

        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();

        currentHapticType = HapticSquare.HapticType.NOISEHIGH;
        haptic.UpdateHaptics(currentHapticType);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHaptic(int option)
    {
        //thisHaptic.DeactivateHaptic();
        //haptic.DeactivateHaptic();
        //haptic.SetEnabled(false);

        switch (option)
        {
            case 1:
                currentHapticType = HapticSquare.HapticType.NOISEHIGH;
                haptic.UpdateHaptics(currentHapticType);
                //haptic.SetEnabled(true);
                Debug.Log(currentHapticType);
                //haptic.ActivateHaptic();
                break;
            case 2:
                currentHapticType = HapticSquare.HapticType.DOTS;
                haptic.UpdateHaptics(currentHapticType);
                //haptic.SetEnabled(true);
                Debug.Log(currentHapticType);
                //haptic.ActivateHaptic();
                break;
            case 3:
                currentHapticType = HapticSquare.HapticType.CHECKERS;
                haptic.UpdateHaptics(currentHapticType);
                //haptic.SetEnabled(true);
                Debug.Log(currentHapticType);
                //haptic.ActivateHaptic();
                break;
            case 4:
                currentHapticType = HapticSquare.HapticType.STRIPEHIGH;
                haptic.UpdateHaptics(currentHapticType);
                //haptic.SetEnabled(true);
                Debug.Log(currentHapticType);
                //haptic.ActivateHaptic();
                break;
        }

    }



    public void ChangeCircuit(int C)
    {
        //haptic.DeactivateHaptic();

        GameObject circuit = GameObject.Find("Circuit");
        SpriteRenderer circuitSpriteR = circuit.GetComponent<SpriteRenderer>();

        switch (C)
        {
            case 1:
                if (this.name == "circuit-outlineS1")
                {
                    circuitSpriteR.sprite = circuitSprite1;
                    
                }
                else { circuitSpriteR.sprite = circuitSprite3; Debug.Log("testing circuit change code"); }
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEHIGH);
                //haptic.ActivateHaptic();
                break;
            case 2:
                circuitSpriteR.sprite = circuitSprite2;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEMED);
                //haptic.ActivateHaptic();
                break;
            case 3:
                if (this.name == "circuit-outlineS1")
                {
                    circuitSpriteR.sprite = circuitSprite3;
                    
                }
                else { circuitSpriteR.sprite = circuitSprite1; Debug.Log("testing circuit change code"); }
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPELOW);
                //haptic.ActivateHaptic();
                break;

        }
    }


    public void SwitchCircuit(int C)
    {
        GameObject circuit = GameObject.Find("Circuit");
        SpriteRenderer circuitSpriteR = circuit.GetComponent<SpriteRenderer>();

        switch (C)
        {
            case 1:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEHIGH2);                
                break;
            case 2:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit2");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEMED2);
                break;
            case 3:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit3");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPELOW2);
                break;

        }
    }

    public void ShowHint()
    {
        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
        else
        {
            hint.SetActive(true);
        }

    }
}
