using TMPro;
using UnityEngine;

public class NPCCounter : MonoBehaviour
{
    [SerializeField] private NPCInteraction[] NPCs;
    [SerializeField] private TMP_Text _walkingText;
    [SerializeField] private TMP_Text _laughingText;
    [SerializeField] private TMP_Text _frightenedText;
    public float walkingCounter;
    public float laughingCounter;
    public float frightenedCounter;

    private void Update()
    {
        UpdateCounter();

        _walkingText.text = "x" + walkingCounter.ToString();
        _laughingText.text = "x" + laughingCounter.ToString();
        _frightenedText.text = "x" + frightenedCounter.ToString();
    }

    private void UpdateCounter()
    {
        walkingCounter = 0;
        laughingCounter = 0;
        frightenedCounter = 0;

        foreach (NPCInteraction npc in NPCs)
        {
            switch (npc.action)
            {
                case NPCInteraction.NPCAction.Walking:
                    walkingCounter += 1; 
                    break;
                case NPCInteraction.NPCAction.Laughing:
                    laughingCounter += 1; 
                    break;
                case NPCInteraction.NPCAction.Frightened:
                    frightenedCounter += 1; 
                    break;
            }
        }
    }
}
