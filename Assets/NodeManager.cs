using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private GameObject nodeListGameObject;             //nodeListGameObject holds all nodes as children in the scene   
    private List<GameObject> nodeList = new List<GameObject>();         //nodeList holds all nodes as gameObject for easy access.

    //List will contain list of nodes.
    void Awake()
    {
        //Add all nodes from parent to the nodeList before starting app.
        nodeListGameObject.GetChildGameObjects(nodeList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  






}
