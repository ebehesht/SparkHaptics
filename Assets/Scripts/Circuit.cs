using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circuit : MonoBehaviour {

    private HapticSquare haptic;
    private string currentHapticType;

    private GameObject hint;

    private Sprite circuitSprite1;
    private Sprite circuitSprite2;
    private Sprite circuitSprite3;

    private Sprite taskSprite;

    GameObject nextButton;
    GameObject finishButton;

    GameObject buttonC1;
    GameObject buttonC2;
    GameObject buttonC3;
    GameObject sliderR;

    SpriteRenderer spriteR;

    PlayerLog thisPlayerLog;
    
    // Use this for initialization
    void Start () {

        if (GlobalVariables.formative) StartFormative();
        else StartTasks();

    }


    private void StartTasks()
    {
        thisPlayerLog = GameObject.Find("EventSystem").GetComponent<PlayerLog>();

        hint = GameObject.Find("Hint");
        hint.SetActive(false);

        Debug.Log("this circuit: " + GlobalVariables.thisTask);
        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();

        nextButton = GameObject.Find("Next Button");
        finishButton = GameObject.Find("Finish Button");

        buttonC1 = GameObject.Find("Circuit1 Button");
        buttonC2 = GameObject.Find("Circuit2 Button");
        buttonC3 = GameObject.Find("Circuit3 Button");

        sliderR = GameObject.Find("SliderR");

        finishButton.SetActive(false);
        buttonC1.SetActive(false);
        buttonC2.SetActive(false);
        buttonC3.SetActive(false);
        sliderR.SetActive(false);

        switch (GlobalVariables.thisTask)
        {
            case 1:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1b");
                taskSprite = Resources.Load<Sprite>("Sprites/Buttons/task1");
                currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                haptic.UpdateHaptics(currentHapticType);
                thisPlayerLog.AddEvent("=============================================\n"
                    + "t = " + Time.time.ToString() + ", Start Task 1"
                    + "\n=============================================");
                break;
            case 2:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit2b");
                taskSprite = Resources.Load<Sprite>("Sprites/Buttons/task2");
                currentHapticType = HapticSquare.HapticType.STRIPEMED2;
                haptic.UpdateHaptics(currentHapticType);
                thisPlayerLog.AddEvent("=============================================\n"
                    + "t = " + Time.time.ToString() + ", Start Task 2"
                    + "\n=============================================");
                break;
            case 3:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1b");
                taskSprite = Resources.Load<Sprite>("Sprites/Buttons/task3");
                currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                haptic.UpdateHaptics(currentHapticType);

                //activate C1 and C2 buttons
                buttonC1.SetActive(true);
                buttonC2.SetActive(true);

                thisPlayerLog.AddEvent("=============================================\n"
                    + "t = " + Time.time.ToString() + ", Start Task 3"
                    + "\n=============================================");
                break;
            case 4:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit4bR1");
                taskSprite = Resources.Load<Sprite>("Sprites/Buttons/task4");
                currentHapticType = HapticSquare.HapticType.STRIPEMED2;
                haptic.UpdateHaptics(currentHapticType);

                //activate slider
                sliderR.SetActive(true);
 
                thisPlayerLog.AddEvent("=============================================\n"
                    + "t = " + Time.time.ToString() + ", Start Task 4"
                    + "\n=============================================");                
                break;
            case 5:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1b");
                taskSprite = Resources.Load<Sprite>("Sprites/Buttons/task5");
                currentHapticType = HapticSquare.HapticType.STRIPEHIGH2;
                haptic.UpdateHaptics(currentHapticType);

                //activate C1 and C2 buttons
                buttonC1.SetActive(true);
                buttonC2.SetActive(true);
                buttonC3.SetActive(true);

                //deactivate the back button
                nextButton.SetActive(false);
                finishButton.SetActive(true);
                

                thisPlayerLog.AddEvent("=============================================\n"
                    + "t = " + Time.time.ToString() + ", Start Task 5"
                    + "\n=============================================");
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

    // formative function
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


    // formative function
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
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit1b");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEHIGH2);
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Clicked Circuit 1");
                break;
            case 2:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit2b");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEMED2);
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Clicked Circuit 2");
                break;
            case 3:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit3b");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPELOW2);
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Clicked Circuit 3");
                break;

        }
    }

    public void ChangeResistance()
    {
        GameObject circuit = GameObject.Find("Circuit");
        SpriteRenderer circuitSpriteR = circuit.GetComponent<SpriteRenderer>();

        Slider mySlider = GameObject.Find("SliderR").GetComponent<UnityEngine.UI.Slider>();
        
        int R = (int) mySlider.value;
        switch (R)
        {
            case 1:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit4bR1");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEMED2);
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Circuit with R=1");
                break;
            case 2:
                circuitSprite1 = Resources.Load<Sprite>("Sprites/Circuits/circuit4bR2");
                circuitSpriteR.sprite = circuitSprite1;
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPELOW2);
                thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Circuit with R=2");
                break;
        }
    }

    public void ShowHint()
    {
        if (hint.activeSelf)
        {
            thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Hide Hint");
            hint.SetActive(false);
        }
        else
        {
            thisPlayerLog.AddEvent("t = " + Time.time.ToString() + ", Show Hint");
            hint.SetActive(true);
        }

    }
}
