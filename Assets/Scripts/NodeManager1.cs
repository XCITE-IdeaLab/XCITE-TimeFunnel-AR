using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager1 : MonoBehaviour
{


    private List<int> nodeList = new List<int> { };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void addNode(GameObject node)
    {
        node.GetComponent<NodeID>().setNodeID(nodeList.Count);
    }


}
