using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    public int nodeID;
    public string NodeName = "null";

    public Action<string> nodeTrigger;

    public NodeEffect nodeEffect;
    public NodeChangeColor nodeColor;
    //connection
    public Node north;
    public Node south;
    public Node east;
    public Node west;
    // kyknya in iyang beratin bikin garbage collection banyak
    private List<Node> connection => new List<Node>(4) { north, east, south, west };

    private void Awake()
    {
        nodeColor = this.GetComponent<NodeChangeColor>();
        nodeEffect = gameObject.GetComponent<NodeEffect>();
    }

    public void Trigger() 
    {
        if (nodeTrigger != null)
        {
            nodeTrigger(gameObject.name); // contoh implementasi
        }
        
    }

    public void SetEffect()
    {
        IEffect effect = GetComponent<IEffect>();
        if (effect == null) return;
    }

    public bool isSpecial()
    {
        string spc = "special";
        string tag = gameObject.tag;

        if (tag.Equals(spc)) return true;
        else return false;
    }

   /* public bool HasEffect()
    {
        return nodeEffect.effectOnNode;
    }*/

    public int NodeActiveConnection()
    {
        int activeConnection = 0;
        foreach (Node n in connection)
        {
            activeConnection += (n != null) ? 1 : 0;
        }
        return activeConnection;
    }

    public List<int> GetConnection_Status()
    {
        List<int> temp = new List<int>();
        foreach (Node n in connection)
        {
            if (n == null)
                temp.Add(0);
            else
                temp.Add(1);
        }
        return temp;
    }

    public List<Node> GetConnection()
    {
        return connection;
    }

    public Node GetDestinationNode(int selected)
    {
        return connection[selected];
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
