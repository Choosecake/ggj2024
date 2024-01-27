using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float _walkCooldown;
    public NPCType type;
    public NPCAction action;

    public enum NPCType
    {
        Normal,
        Vampire,
        Clown
    }

    public enum NPCAction
    {
        Walking,
        Laughing,
        Frightened
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NPCInteraction>() != null) 
        {
            NPCInteraction npc = other.gameObject.GetComponent<NPCInteraction>();
            if (npc.type == NPCType.Normal)
            {
                if (this.type == NPCType.Vampire)
                {
                    if (npc.action != NPCAction.Frightened)
                    {
                        npc.action = NPCAction.Frightened;
                        npc.GetComponent<NPCWalk>().currentState = NPCWalk.NPCWalkingState.StopWalking;

                        StartCoroutine(StartWalking(npc));
                    }

                }

                if (this.type == NPCType.Clown)
                {
                    if (npc.action == NPCAction.Frightened)
                    {
                        npc.action = NPCAction.Laughing;
                        npc.GetComponent<NPCWalk>().currentState = NPCWalk.NPCWalkingState.StopWalking;

                        StartCoroutine(StartWalking(npc));
                    }
                }
            }
        }
    }

    private IEnumerator StartWalking(NPCInteraction npc)
    {
        if (action == NPCAction.Walking) yield return null;

        yield return new WaitForSeconds(_walkCooldown);

        npc.action = NPCAction.Walking;
        npc.gameObject.GetComponent<NPCWalk>().ChangeState(NPCWalk.NPCWalkingState.Walking);
    }
}
