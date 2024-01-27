using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPosition : MonoBehaviour
{
    [SerializeField] private GameObject _centerObject;
    [SerializeField] private GameObject _mirrorObject;

    void Update()
    {
        Vector3 distance = _mirrorObject.transform.position - _centerObject.transform.position;
        transform.position = -distance;
    }
}
