using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchEvents : MonoBehaviour {
    private HapticSquare haptic;
    private GameObject touched;
    private Vector3 touchPosWorld; //for the hitInformation object
    private Vector3 touchPosWorldPrev;    

    // Use this for initialization
    void Start ()
    {
        haptic = GameObject.Find("HapticSquare").GetComponent<HapticSquare>();
        Debug.Log("executing touchevents script");
    }

    // Update is called once per frame
    void Update()
    {

        // TOUCH BEGIN//

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //transform the touch position into world space from screen space and store it.
            touchPosWorldPrev = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        // TOUCH MOVE //

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //transform the touch position into world space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);


            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider, find if the circuit outline is touched
                string thisZone = hitInformation.transform.gameObject.tag;
                if (thisZone == "LeftZone")
                {
                    FlowCurrent("left");
                }
                else if (thisZone == "RightZone")
                {
                    FlowCurrent("right");
                }
                else if (thisZone == "DownZone")
                {
                    FlowCurrent("down");
                }
                else if (thisZone == "UpZone")
                {
                    FlowCurrent("up");
                }
                else
                {
                    haptic.SetEnabled(false);
                    Debug.Log("ERROR");
                }
            }
            else
            {
                haptic.SetEnabled(false);
                Debug.Log("moving out of the outline!");
            }
            touchPosWorldPrev = touchPosWorld;
        }

        // TOUCH END //
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            haptic.SetEnabled(false);
            Debug.Log("touch end circuit outline");

        }
    }

    private void FlowCurrent(string dir)
    {

        if (Moving(touchPosWorldPrev, touchPosWorld, dir))
        {
            haptic.SetEnabled(true);
            haptic.UpdateHaptics(HapticSquare.HapticType.TEST);
            Debug.Log("moving " + dir);
        }
        else
        {
            //haptic.DeactivateHaptic();
            haptic.SetEnabled(true);
            haptic.UpdateHaptics(HapticSquare.HapticType.NOISELOW);
            Debug.Log("moving opposite direction!");
        }

    }

    private bool Moving(Vector3 v1, Vector3 v2, string direction)
    {
        if (direction == "left")
        {
            if (v1.x > v2.x) return true;
            else return false;
        }
        else if (direction == "right")
        {
            if (v1.x < v2.x) return true;
            else return false;
        }
        else if (direction == "down")
        {
            if (v1.y > v2.y) return true;
            else return false;
        }
        else if (direction == "up")
        {
            if (v1.y < v2.y) return true;
            else return false;
        }
        else return false;
    }
}
