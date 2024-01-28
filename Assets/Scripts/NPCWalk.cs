using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _moonRaycast;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    public NPCWalkingState currentState = NPCWalkingState.Walking;

    public enum NPCWalkingState
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
            case NPCWalkingState.Walking:
                Walk();
                break;
            case NPCWalkingState.StopWalking:
                StopWalking();
                break;
            case NPCWalkingState.TurnRight:
                TurnRight();
                break;
            case NPCWalkingState.TurnLeft:
                TurnLeft();
                break;
            case NPCWalkingState.TurnBackwards:
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
                ChangeState(NPCWalkingState.TurnLeft);
            }
            else if (Random.Range(0, 2) == 1)
            {
                ChangeState(NPCWalkingState.TurnRight);
            }
            else if (Random.Range(0, 2) == 2)
            {
                ChangeState(NPCWalkingState.TurnBackwards);
            }
        }
    }

    private void StopWalking()
    {

    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, _turnSpeed);
        ChangeState(NPCWalkingState.Walking);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -_turnSpeed);
        ChangeState(NPCWalkingState.Walking);
    }

    private void TurnBackwards()
    {
        transform.Rotate(Vector3.up, 180f);
        ChangeState(NPCWalkingState.Walking);
    }

    public void ChangeState(NPCWalkingState newState)
    {
        currentState = newState;
    }
}
