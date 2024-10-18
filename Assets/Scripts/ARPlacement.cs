using System.Collections.Generic;  // For List<T>
using UnityEngine;
using UnityEngine.XR.ARFoundation;  // For ARRaycastManager
using UnityEngine.XR.ARSubsystems;  // For TrackableType

public class ARPlacement : MonoBehaviour
{
    public GameObject objectToPlace;  // Object to be placed in AR
    private ARRaycastManager raycastManager;  // Reference to ARRaycastManager
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();  // List to store raycast hits

    void Start()
    {
        // Get the ARRaycastManager component from AR Session Origin
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Check for user touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Perform raycast when user taps the screen
            if (touch.phase == TouchPhase.Began)
            {
                // Perform a raycast to detect planes and trackable surfaces
                if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    // Get the first hit result
                    Pose hitPose = hits[0].pose;

                    // Instantiate the object at the hit position
                    Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
