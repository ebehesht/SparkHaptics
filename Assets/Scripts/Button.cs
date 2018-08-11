using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private HapticSquare haptic;

    // different textures
    private HapticSquare hapticA;
    private HapticSquare hapticB;
    private HapticSquare hapticC;
    private HapticSquare hapticD;

    // strength
    private HapticSquare haptic1;
    private HapticSquare haptic2;
    private HapticSquare haptic3;

    private Sprite spriteA1;
    private Sprite spriteA2;
    private Sprite spriteA3;

    // Use this for initialization
    void Start () {

        Debug.Log("starting executing button script");

        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
        if (haptic != null) haptic.DeactivateHaptic();

        //hapticA = GameObject.Find("HapticSquareA").GetComponent<HapticSquare>();
        //if (hapticA != null) hapticA.DeactivateHaptic();

        //hapticB = GameObject.Find("HapticSquareB").GetComponent<HapticSquare>();
        //if (hapticB != null) hapticB.DeactivateHaptic();

        //hapticC = GameObject.Find("HapticSquareC").GetComponent<HapticSquare>();
        //if (hapticC != null) hapticC.DeactivateHaptic();

        //hapticD = GameObject.Find("HapticSquareD").GetComponent<HapticSquare>();
        //if (hapticD != null) hapticD.DeactivateHaptic();

        //// Current strength
        //haptic1 = GameObject.Find("HapticSquare1").GetComponent<HapticSquare>();
        //if (haptic1 != null) haptic1.DeactivateHaptic();

        //haptic2 = GameObject.Find("HapticSquare2").GetComponent<HapticSquare>();
        //if (haptic2 != null) haptic2.DeactivateHaptic();

        //haptic3 = GameObject.Find("HapticSquare3").GetComponent<HapticSquare>();
        //if (haptic3 != null) haptic3.DeactivateHaptic();

        spriteA1 = Resources.Load<Sprite>("Sprites/Circuits/circuitA");
        spriteA2 = Resources.Load<Sprite>("Sprites/Circuits/circuitA2");
        spriteA3 = Resources.Load<Sprite>("Sprites/Circuits/circuitA3");

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
                SceneManager.LoadScene("CircuitA Options");
                break;
            case 3:
                SceneManager.LoadScene("CircuitA Strength V2");
                break;
            case 4:
                SceneManager.LoadScene("CircuitA Strength");
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
                SceneManager.LoadScene("CircuitA Strength V2");
                break;

        }
    }

    public void ChangeHaptic(int option)
    {
        //thisHaptic.DeactivateHaptic();
        hapticA.DeactivateHaptic();
        hapticB.DeactivateHaptic();
        hapticC.DeactivateHaptic();
        hapticD.DeactivateHaptic();

        switch (option)
        {
            case 1:
                hapticA.ActivateHaptic();
                //thisHaptic = hapticA;
                break;
            case 2:
                hapticB.ActivateHaptic();
                //thisHaptic = hapticB;
                break;
            case 3:
                hapticC.ActivateHaptic();
                //thisHaptic = hapticC;
                break;
            case 4:
                hapticD.ActivateHaptic();
                //thisHaptic = hapticD;
                break;
        }    

    }



    public void ChangeCircuit(int C)
    {
        haptic1.DeactivateHaptic();
        haptic2.DeactivateHaptic();
        haptic3.DeactivateHaptic();

        GameObject circuit = GameObject.Find("Circuit");
        SpriteRenderer circuitSpriteR = circuit.GetComponent<SpriteRenderer>();

        switch (C)
        {
            case 1:
                if (this.tag == "ButtonA")
                {
                    circuitSpriteR.sprite = spriteA1;
                }
                else { circuitSpriteR.sprite = spriteA3; }
                haptic1.ActivateHaptic();                
                break;
            case 2:
                circuitSpriteR.sprite = spriteA2;
                haptic2.ActivateHaptic();                
                break;
            case 3:
                if (this.tag == "ButtonA")
                {
                    circuitSpriteR.sprite = spriteA3;
                }
                else { circuitSpriteR.sprite = spriteA1; }
                haptic3.ActivateHaptic();                
                break;

        }
    }
}
