﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerNodeManager : MonoBehaviour
{
    
    [SerializeField]private PathSelector _pathSelect;

    public Transform destinationTransform;
    public Node destinationNode;
    public Node currentNode;
    public Node previousNode;

    private void Start()
    {
        GameMechanicReference ins = GameMechanicReference.Instance;
        _pathSelect = ins.GetPathSelector;
        destinationNode = ins.GetDestinationNode;
        destinationTransform = destinationNode.GetTransform();
        currentNode = ins.GetStartNode;
    }
    public void OnReachedDestination()
    {
        previousNode = currentNode;
        currentNode = destinationNode;

        destinationNode = null;
        destinationTransform = null;
    }

    public void OnSelectedNode(Node selectedNode)
    {
        destinationNode = selectedNode;
        destinationTransform = destinationNode.GetTransform();
    }

    public void GetNextDestination()
    {
        Node selectedNode = _pathSelect.PathSelecting(currentNode, previousNode);
        
        if (selectedNode == null) return;

        _pathSelect.CloseSelectorUI();
        OnSelectedNode(selectedNode);

    }

}