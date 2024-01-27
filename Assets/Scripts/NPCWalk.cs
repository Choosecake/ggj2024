using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _moonRaycast;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    public VillagerState currentState = VillagerState.Walking;

    public enum VillagerState
    {
        Walking,
        StopWalking,
        TurnRight,
        TurnLeft,
        TurnBackwards,
    }

    void Update()
    {
        switch (currentState)
        {
            case VillagerState.Walking:
                Walk();
                break;
            case VillagerState.StopWalking:
                StopWalking();
                break;
            case VillagerState.TurnRight:
                TurnRight();
                break;
            case VillagerState.TurnLeft:
                TurnLeft();
                break;
            case VillagerState.TurnBackwards:
                TurnBackwards();
                break;
        }
    }
    private void Walk()
    {
        Vector3 direction = _planet.transform.position - transform.position;
        direction.Normalize();
        transform.rotation = Quaternion.FromToRotation(transform.up, direction) * transform.rotation;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (Random.Range(0, 1000) == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                ChangeState(VillagerState.TurnLeft);
            }
            else if (Random.Range(0, 2) == 1)
            {
                ChangeState(VillagerState.TurnRight);
            }
            else if (Random.Range(0, 2) == 2)
            {
                ChangeState(VillagerState.TurnBackwards);
            }
        }
    }

    private void StopWalking()
    {

    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, _turnSpeed);
        ChangeState(VillagerState.Walking);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -_turnSpeed);
        ChangeState(VillagerState.Walking);
    }

    private void TurnBackwards()
    {
        transform.Rotate(Vector3.up, 180f);
        ChangeState(VillagerState.Walking);
    }

    public void ChangeState(VillagerState newState)
    {
        currentState = newState;
    }
}
