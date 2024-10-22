using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private GameObject masterList;                  // masterList holds list of all the segments
    [SerializeField] private GameObject selectedSegmentList;         // selectedSegmentList holds list of all nodes in selected segment
    private GameObject selectedNode;                                 // selectedNode holds reference to the currently selected node

    //List will contain list of nodes.
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
  






}
