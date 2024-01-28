using UnityEngine;

public class ClownWalk : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _moonRaycast;
    [SerializeField] private GameObject _groundRaycast;
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
                transform.position = Vector3.Lerp(transform.position, hit.point, _speed * Time.deltaTime);
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.collider.gameObject.transform.position - transform.position) * transform.rotation;
                //transform.Translate((hit.point - transform.position) * _speed * Time.deltaTime);
            }
        }
    }
}
