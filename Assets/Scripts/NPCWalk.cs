using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _moon;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    private VillagerState currentState = VillagerState.Walking;

    public enum VillagerState
    {
        Walking,
        StopWalking,
        TurnRight,
        TurnLeft,
        TurnBackwards,
        FollowMoon
    }

    void Update()
    {
        if (this.CompareTag("VampClown"))
        {
            FollowMoon();
        }

        switch (currentState)
        {
            case VillagerState.Walking:
                Walk();
                break;
            case VillagerState.StopWalking:
                // Stop walking
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
        Vector3 centerDirection = _planet.transform.position - transform.position;
        centerDirection.Normalize();
        transform.rotation = Quaternion.FromToRotation(transform.up, centerDirection) * transform.rotation;
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

    private void FollowMoon()
    {
        ChangeState(VillagerState.FollowMoon);

        Vector3 centerDirection = _planet.transform.position - transform.position;
        centerDirection.Normalize();
        transform.rotation = Quaternion.FromToRotation(transform.up, centerDirection) * transform.rotation;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void ChangeState(VillagerState newState)
    {
        currentState = newState;
    }
}
