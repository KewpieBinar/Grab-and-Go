using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOnClick : MonoBehaviour
{
    [SerializeField]
    private Material originalMaterial;
    [SerializeField]
    private Material onEffectMaterial;

    private MeshRenderer _myMeshRender;

    private void Awake()
    {
        _myMeshRender = this.GetComponent<MeshRenderer>();
    }

    public void OnNodeClick()
    {
        _myMeshRender.material = onEffectMaterial;
    }

    public void OnEffectActivate()
    {
        _myMeshRender.material = originalMaterial;
    }
}
