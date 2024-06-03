using UnityEngine;

public class NodeChangeColor : MonoBehaviour
{
    [SerializeField]
    private Material originalMaterial;
    [SerializeField]
    private Material onEffectMaterial;

    [SerializeField]
    private MeshRenderer meshRender;

    private void Awake()
    {
        if (meshRender == null) meshRender = this.GetComponent<MeshRenderer>();
    }

    public void Color_Original()
    {
        meshRender.material = originalMaterial;
    }

    public void Color_OnEffect()
    {
        meshRender.material = onEffectMaterial;
    }
}