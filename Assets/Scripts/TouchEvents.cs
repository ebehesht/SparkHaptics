using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchEvents : MonoBehaviour {
    private HapticSquare haptic;
    private GameObject touched;
    private bool isTouched = false;
    private Vector3 touchPosWorld; //for the hitInformation object
    //private Vector3 offset;    

    // Use this for initialization
    void Start () {

        Debug.Log("executing touchevents script");

    }

    // Update is called once per frame
    void Update()
    {

        // TOUCH BEGIN//

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            

            ////transform the touch position into world space from screen space and store it.
            //touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            ////raycast with this information. If we have hit something we can process it.
            //RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            //if (hitInformation.collider != null)
            //{
            //    //We should have hit something with a 2D Physics collider, find if the circuit outline is touched
            //    if (hitInformation.transform.gameObject.tag == "Outline")
            //    {
            //        touched = hitInformation.transform.gameObject;
            //        //offset = touchPosWorld - touched.transform.position;
            //        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
            //        if (haptic != null) haptic.ActivateHaptic();
            //        Debug.Log("touch start circuit outline");

            //        isTouched = true;

            //    }
            //}
        }

        // TOUCH MOVE //

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //transform the touch position into world space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            //if (isTouched)
            //{
                if (hitInformation.collider != null)
                {
                    //We should have hit something with a 2D Physics collider, find if the circuit outline is touched
                    if (hitInformation.transform.gameObject.tag == "Outline")
                    {
                        touched = hitInformation.transform.gameObject;
                        //offset = touchPosWorld - touched.transform.position;
                        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
                        if (haptic != null) haptic.ActivateHaptic();
                        Debug.Log("touching circuit outline");
                }
                }
                else
                {
                    haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
                    if (haptic != null) haptic.DeactivateHaptic();
                    //isTouched = false;
                    Debug.Log("Oh oh oh!");
                }

            //}
            //else
            //{
            //    if (hitInformation.collider != null)
            //    {
            //        //We should have hit something with a 2D Physics collider, find if the circuit outline is touched
            //        if (hitInformation.transform.gameObject.tag == "Outline")
            //        {
            //            touched = hitInformation.transform.gameObject;
            //            //offset = touchPosWorld - touched.transform.position;
            //            haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
            //            if (haptic != null) haptic.ActivateHaptic();
            //        }
            //    }
            //    else
            //    {
            //        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
            //        if (haptic != null) haptic.DeactivateHaptic();
            //        isTouched = false;
            //        Debug.Log("Oh oh oh!");
            //    }

            //}


        }

        // TOUCH END //
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
            if (haptic != null) haptic.DeactivateHaptic();
            isTouched = false;
            Debug.Log("touch end circuit outline");

        }
    }
}
