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

    // Use this for initialization
    void Start () {

        Debug.Log("executing circuit");

        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();

        currentHapticType = HapticSquare.HapticType.CHECKERS;
        //haptic.UpdateHaptics(currentHapticType);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
