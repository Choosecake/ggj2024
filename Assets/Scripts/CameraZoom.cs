using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private ClownWalk _clownWalk;
    [SerializeField] private float _regularFOV;
    [SerializeField] private float _zoomFOV;
    [SerializeField] private float _speed;
    private Camera _camera;
    private Transform _originalTransform;
    private bool _isZoomedIn;
    private Vector3 _clown;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _clown = _clownWalk.gameObject.transform.position;
        _originalTransform = transform;
    }

    public void ZoomIn()
    {
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoomFOV, _speed * Time.deltaTime);
    }
    public void ZoomOut()
    {
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _regularFOV, _speed * 2 * Time.deltaTime);
    }
}