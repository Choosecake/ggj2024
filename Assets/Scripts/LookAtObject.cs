using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    void Update()
    {
        transform.LookAt(_target.transform);
    }
}
