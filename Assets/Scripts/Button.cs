using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private HapticSquare haptic;

    private Sprite spriteA1;
    private Sprite spriteA2;
    private Sprite spriteA3;

    // Use this for initialization
    void Start () {

        Debug.Log("starting executing button script");

        //haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
        //if (haptic != null) haptic.DeactivateHaptic();

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
        //haptic.DeactivateHaptic();

        switch (option)
        {
            case 1:
                //currentHapticType = WheelHaptics.HapticType.BUMPY;
                
                haptic.UpdateHaptics(HapticSquare.HapticType.NOISEHIGH);
                //haptic.ActivateHaptic();
                break;
            case 2:
                haptic.UpdateHaptics(HapticSquare.HapticType.DOTS);
                //haptic.ActivateHaptic();
                break;
            case 3:
                haptic.UpdateHaptics(HapticSquare.HapticType.CHECKERS);
                //haptic.ActivateHaptic();
                break;
            case 4:
                haptic.UpdateHaptics(HapticSquare.HapticType.STRIPEHIGH);
                //haptic.ActivateHaptic();
                break;
        }    

    }



    public void ChangeCircuit(int C)
    {
        haptic.DeactivateHaptic();

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
                haptic.UpdateHaptics(HapticSquare.HapticType.NOISEHIGH);
                haptic.ActivateHaptic();
                break;
            case 2:
                circuitSpriteR.sprite = spriteA2;
                haptic.UpdateHaptics(HapticSquare.HapticType.NOISEMED);
                haptic.ActivateHaptic();
                break;
            case 3:
                if (this.tag == "ButtonA")
                {
                    circuitSpriteR.sprite = spriteA3;
                }
                else { circuitSpriteR.sprite = spriteA1; }
                haptic.UpdateHaptics(HapticSquare.HapticType.NOISELOW);
                haptic.ActivateHaptic();
                break;

        }
    }
}
