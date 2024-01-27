using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;


    private void Update()
    {
        transform.RotateAround(_target.transform.position, new Vector3(0, 1, 0), _speed * Time.deltaTime);
    }
}
