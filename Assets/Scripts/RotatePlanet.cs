using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _moon;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensitivity;
    [HideInInspector] public bool isDragging;
    private Vector2 _mouseMovement;
    private GameObject _currentObject;
    private CameraZoom _zoom;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _zoom = _camera.gameObject.GetComponent<CameraZoom>();
    }

    void Update()
    {
/*
        DetectPlanet();
        if (!isDragging) return;
*/
        MakeRotation();
    }

    private void DetectPlanet()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Moon"))
            {
                if (isDragging) return;
                _currentObject = _moon;
                isDragging = true;
            }
            else if (hit.collider.gameObject.CompareTag("Planet"))
            {
                if (isDragging) return;
                _currentObject = _planet;
                isDragging = true;
            }
        }
    }

    private void MakeRotation()
    {
        _mouseMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetMouseButton(0))
        {
            _currentObject = _moon;
            _zoom.ZoomIn();
        }
        else
        {
            _currentObject = _planet;
            _zoom.ZoomOut();
        }

        Vector3 right = Vector3.Cross(_camera.transform.up, _currentObject.transform.position - _camera.transform.position);
        Vector3 up = Vector3.Cross(_currentObject.transform.position - _camera.transform.position, right);
        _currentObject.transform.rotation = Quaternion.AngleAxis(-_mouseMovement.x * _sensitivity, up) * _currentObject.transform.rotation;
        _currentObject.transform.rotation = Quaternion.AngleAxis(_mouseMovement.y * _sensitivity, right) * _currentObject.transform.rotation;
    }
}
