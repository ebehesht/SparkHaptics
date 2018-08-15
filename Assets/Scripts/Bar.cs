﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    private HapticSquare haptic;
    private string currentHapticType;

    // Use this for initialization
    void Start () {

        if (this.name == "barA")
        {
            haptic = GameObject.Find("HapticSquareA").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR01);
        }
        else if (this.name == "barB")
        {
            haptic = GameObject.Find("HapticSquareB").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR03);
        }
        else if (this.name == "barC")
        {
            haptic = GameObject.Find("HapticSquareC").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR04);
        }
        else if (this.name == "barD")
        {
            haptic = GameObject.Find("HapticSquareD").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR11);
        }
        else if (this.name == "barE")
        {
            haptic = GameObject.Find("HapticSquareE").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR12);
        }
        else if (this.name == "barF")
        {
            haptic = GameObject.Find("HapticSquareF").GetComponent<HapticSquare>();
            haptic.UpdateHaptics(HapticSquare.HapticType.BAR13);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
