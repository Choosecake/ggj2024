using System.Collections;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float _walkCooldown;
    private DisplayReaction _displayReaction;
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

    private void Start()
    {
        _displayReaction = GetComponent<DisplayReaction>();
    }

    private void Update()
    {
        if (type == NPCType.Normal)
        {
            if (_displayReaction == null) return;
            SpriteRenderer spriteRenderer = _displayReaction.spriteRenderer;
            if (action == NPCAction.Walking)
            {
                spriteRenderer.color = Color.black;
                _displayReaction.SetSprite(0);
            }
            else if (action == NPCAction.Laughing)
            {
                spriteRenderer.color = Color.green;
                _displayReaction.SetSprite(1);
            }
            else if (action == NPCAction.Frightened)
            {
                spriteRenderer.color = Color.red;
                _displayReaction.SetSprite(2);
            }
        }
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
                        _displayReaction.SetSprite(1);
                        StartCoroutine(ResetReaction());

                        npc.action = NPCAction.Frightened;
                        npc.GetComponent<NPCWalk>().currentState = NPCWalk.NPCWalkingState.StopWalking;

                        StartCoroutine(StartWalking(npc));
                    }

                }

                if (this.type == NPCType.Clown)
                {
                    if (npc.action != NPCAction.Laughing)
                    {
                        _displayReaction.SetSprite(1);
                        StartCoroutine(ResetReaction());

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

    private IEnumerator ResetReaction()
    {
        yield return new WaitForSeconds(1.5f);
        _displayReaction.SetSprite(0);
    }
}
