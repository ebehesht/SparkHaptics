using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchEvents : MonoBehaviour {
    bool chargeIsTapped;
    GameObject touchedCharge;
    Vector3 touchPosWorld;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        chargeIsTapped = false;
	}

    // Update is called once per frame
    void Update() {

        // TOUCH BEGIN//

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            //transform the touch position into world space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);



                
            // for current applications
            GameObject thisOutline = GameObject.Find("circuit-outline");
            if (thisOutline != null)
            {
                Debug.Log("touched circuit outline");
                GameObject haptic = thisOutline.transform.GetChild(0).gameObject;
                haptic.SetActive(true);

            }

            // for resistor application
            GameObject thisInside = GameObject.Find("Component");
            if (thisInside != null)
            {
                Debug.Log("touched inside resistor");
                GameObject haptic;
                for (int i = 0; i < 4; i++)
                {
                    haptic = thisInside.transform.GetChild(i).gameObject;
                    haptic.SetActive(false);
                    haptic.GetComponent<HapticSetting>().ActivateHaptic(false);
                }
                haptic = thisInside.transform.GetChild(GlobalVariables.RGlobal - 1).gameObject;
                haptic.SetActive(true);
                haptic.GetComponent<HapticSetting>().ActivateHaptic(true);

            }
            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                //find the object that is touched
                // touched = Resistor
                if (hitInformation.transform.gameObject.tag == "Resistor")
                {
                    //touchedCharge = hitInformation.transform.gameObject;
                    //chargeIsTapped = true;
                    //offset = touchPosWorld - touchedCharge.transform.position;
                    //Debug.Log("Touched " + touchedCharge.name);


                    SceneManager.LoadScene("Resistance");


                }

            }

            /*

            // touched = circuit outline 
            if (hitInformation.transform.gameObject.tag == "Outline")
            {
                GameObject thisOutline = GameObject.Find("circuit-outline");
                if (thisOutline != null)
                {
                    Debug.Log("touched circuit outline");
                    GameObject haptic = thisOutline.transform.GetChild(0).gameObject;
                    haptic.SetActive(true);

                }

            }

            // touched = Resistor
            else if (hitInformation.transform.gameObject.tag == "Resistor")
            {
                touchedCharge = hitInformation.transform.gameObject;
                chargeIsTapped = true;
                offset = touchPosWorld - touchedCharge.transform.position;
                Debug.Log("Touched " + touchedCharge.name);


                SceneManager.LoadScene("Resistance");


            }

            // touched = Inside view of resistor
            else if (hitInformation.transform.gameObject.tag == "Inside")
            {                    
                GameObject thisComponent = GameObject.Find("Component");
                if (thisComponent != null)
                {
                    GameObject haptic;
                    for (int i = 0; i < 4; i++)
                    {
                        haptic = thisComponent.transform.GetChild(i).gameObject;
                        haptic.SetActive(false);
                    }
                    haptic = thisComponent.transform.GetChild(GlobalVariables.RGlobal - 1).gameObject;
                    haptic.SetActive(true);

                }

            }
            */


            //}
        }

        // TOUCH MOVE //

        if (Input.touchCount > 0 && chargeIsTapped && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            /*
            // Get movement of the finger since last frame
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 newChargePosition = touchPosWorld - offset;
            touchedCharge.transform.position = new Vector3(newChargePosition.x, newChargePosition.y, newChargePosition.z);
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //float speed = 0.1f;

            // Move object across XY plane
            //touchedBunny.transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
            */
        }

        // TOUCH END //
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            GameObject thisOutline = GameObject.Find("circuit-outline");
            if (thisOutline != null)
            {
                Debug.Log("now deactivate the haptics");
                GameObject haptic = thisOutline.transform.GetChild(0).gameObject;
                haptic.SetActive(false);

            }

            // for resistor application
            GameObject thisInside = GameObject.Find("Component");
            if (thisInside != null)
            {
                Debug.Log("touched inside resistor");
                GameObject haptic = thisInside.transform.GetChild(GlobalVariables.RGlobal - 1).gameObject;
                haptic.GetComponent<HapticSetting>().ActivateHaptic(false);

            }




            //chargeIsTapped = false; //end the touch

        }
    }
}
