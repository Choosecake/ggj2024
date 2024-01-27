using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownWalk : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _moonRaycast;
    [SerializeField] private float _speed;

    void Update()
    {
        FollowMoon();
    }

    private void FollowMoon()
    {
        RaycastHit hit;
        Vector3 direction;
        if (Physics.Raycast(_moonRaycast.transform.position, _moonRaycast.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Planet"))
            {
                print("a");
                direction = hit.collider.gameObject.transform.position;

                Vector3 right = Vector3.Cross(_camera.transform.up, transform.position - _camera.transform.position);
                Vector3 up = Vector3.Cross(transform.position - _camera.transform.position, right);

                transform.rotation = Quaternion.AngleAxis(-direction.x * _speed, up) * transform.rotation;
                transform.rotation = Quaternion.AngleAxis(direction.y * _speed, right) * transform.rotation;

            }
        }
    }
}
