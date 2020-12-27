using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayCastManager;
    private GameObject visual; //plane object created with the ARPlacementIndicator

    void Start ()
    {
        //get all components from scene
        rayCastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;


        //disable the visual on initiation
        visual.SetActive(false);
    }

    private void Update()
    {
        //shoot a raycast from the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayCastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit the ar plane, update the position and rotation of the AR object
        if (hits.Count > 0)
        {
            //set the position and rotation of the game object based on hits
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            //set the visual as active if not already active
            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
