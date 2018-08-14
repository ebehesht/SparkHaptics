using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int thisCircuit = 1;
    public static int RGlobal = 1;
}

public class Circuit : MonoBehaviour {

    private HapticSquare haptic;
    private string currentHapticType;

    private Sprite spriteA1;
    private Sprite spriteA2;
    private Sprite spriteA3;

    // Use this for initialization
    void Start () {

        Debug.Log("executing circuit");

        // circuits for testing different circuits with high, med, low current
        spriteA1 = Resources.Load<Sprite>("Sprites/Circuits/circuitA");
        spriteA2 = Resources.Load<Sprite>("Sprites/Circuits/circuitA2");
        spriteA3 = Resources.Load<Sprite>("Sprites/Circuits/circuitA3");

        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();

        currentHapticType = HapticSquare.HapticType.TEST;
        haptic.UpdateHaptics(currentHapticType);
    }
	
	// Update is called once per frame
	void Update () {
		
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
