using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]
    private float _horizontalSpeed = 1f;
    [SerializeField]
    private float _verticalSpeed = 1f;

    private void Awake()
    {
        _mainCamera = this.GetComponent<Camera>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal * Time.deltaTime * _horizontalSpeed, 0, vertical * Time.deltaTime * _verticalSpeed);
    }
}
