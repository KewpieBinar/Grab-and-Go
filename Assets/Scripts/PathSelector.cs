﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSelector : MonoBehaviour
{
    public PathSelectorUI UI_pathSelect;

    private bool selectorOpen = false;
    //public List<int> nodeStatus;

    public Transform UI_transform;

    public void OpenSelector(Node currentNode)
    {
        if (!selectorOpen)
        {
            var stats = currentNode.GetConnection_Status();
            selectorOpen = true;
            UI_pathSelect.OpenToggleUI(true, stats, currentNode.GetTransform());
        }
    }

 /*   public int GetSelected() // listen to this
    {
        int temp = UI_pathSelect.Selected;
        *//*if (temp >= 0)
        {
            
           
            return temp;
        }
        else
        {
            return -1;
        }*//*
        return temp;

    }*/

    public Node PathSelecting (Node current, Node previous) // USE THIS
    {
        int nodeBranch = current.NodeActiveConnection();

        if(nodeBranch == 2)
        {
            var nextNode = AutoSelection(current, previous);
            return nextNode;
        }

        if(nodeBranch > 2)
        {
            var nextNode = ManualSelection(current);
            return nextNode;
        }

        return null;
    }

    public Node AutoSelection(Node current , Node previous)
    {
        foreach (Node n in current.GetConnection())
        {
            if (n != null && n != previous)
            {
                return n;
            }
        }

        return null;
    }

    public Node ManualSelection(Node current)
    {
        OpenSelector(current);

        //int selected = GetSelected();

        var selected = UI_pathSelect.Selected;

        if (selected < 0) return null;

        //selectorOpen = false;

        var nd = current.GetDestinationNode(selected);

        return nd;
    }

    public void CloseSelectorUI()
    {
        UI_pathSelect.DisableUI();
        selectorOpen = false;
    }
}
