using UnityEngine;

public class PullDown : MonoBehaviour
{
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(-transform.up, ForceMode.VelocityChange);
    }
}
