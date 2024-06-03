using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlacementManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask _nodeLayer;
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    private PlayerEffectManager playerEffectmanager = null;

    public bool placeEffect;

    private void Awake()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }
   
    void Update()
    {
        if (!placeEffect) return;
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit,_nodeLayer))
            {
                Transform objHit = raycastHit.transform;
                Node nodeHit = objHit.GetComponent<Node>();
                if (nodeHit == null) return;
                Debug.Log(string.Format("{0} ini kena", objHit.name));
                CallRPC_SetNode(nodeHit);
            }
        }
    }

    public void StartPlaceEffect(PlayerEffectManager pEffectManager)
    {
        Debug.Log("Start placement");
        playerEffectmanager = pEffectManager;
        placeEffect = true;
    }

    public void CallRPC_SetNode(Node nodeToPlace)
    {
        playerEffectmanager.SetOnNode(nodeToPlace.GetTransform().name);
        // kalo di call matiin placeEffectnya
        placeEffect = false;
    }

    

    
}
