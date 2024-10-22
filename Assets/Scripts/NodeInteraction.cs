using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NodeInteraction : MonoBehaviour
{
    // Reference to all the canvases in the scene (which contain the info screens)
    public GameObject[] canvases;

    void Update()
    {
        //touchInput();
        mouseInput();
    }

    private void touchInput()
    {
        // Check if there is a touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform raycast to detect nodes
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

                        if (hit.collider.CompareTag("Node"))
                        {
                            Debug.Log("Hit a node: " + hit.collider.gameObject.name);
                            int nodeId = hit.collider.gameObject.GetComponent<NodeID>().nodeID;
                            //ShowCanvasForNode(nodeId);
                        }
                    }
                    else
                    {
                        Debug.Log("Raycast did not hit any object.");
                    }
                }
            }
        }
    }


    private void mouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform raycast to detect nodes
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Node"))
                {
                    Debug.Log("Hit a node: " + hit.collider.gameObject.name);
                   
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }
        }
    }

    // Show the canvas associated with the selected node
    /*    void ShowCanvasForNode(int nodeId)
    {
        Debug.Log("Node selected with ID: " + nodeId);

        // Deactivate all canvases first
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        // Activate the correct canvas
        foreach (GameObject canvas in canvases)
        {
            NodeInfoScreen infoScreen = canvas.GetComponent<NodeInfoScreen>();
            if (infoScreen.nodeId == nodeId)
            {
                Debug.Log("Activating canvas for node: " + nodeId);
                canvas.SetActive(true);
                break;
            }
        }
    }*/

}
