using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapList : MonoBehaviour
{
    public static NodeMapList nodeMapList;

    public List<GameObject> nodeObjList = new List<GameObject>();
    public List<Node> nodeList = new List<Node>();
    private void Awake()
    {
        nodeMapList = this;
        StartCoroutine(CR_nodeMapping());
    }

    private IEnumerator CR_nodeMapping()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject nodeObj = transform.GetChild(i).gameObject;
            nodeObjList.Add(nodeObj);
            yield return null;
        }
        
    }

    public Node GetNodeByObjectName(string objectName)
    {
        /*foreach(GameObject obj in nodeObjList)
        {
            var objName = obj.name;
            if(objectName.Equals(objName))
            {
                return obj.GetComponent<Node>();
            }
        }*/

        foreach(Node node in nodeList)
        {
            string objName = node.transform.name;
            if (objectName.Equals(objName))
            {
                return node;
            }
        }

        Debug.LogError("No Node by the name "+objectName,this);
        return null;
        
    }
}
