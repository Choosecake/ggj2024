using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCounter : MonoBehaviour
{
    [SerializeField] private NPCInteraction[] NPCs;
    [SerializeField] private TMP_Text _walkingText;
    [SerializeField] private TMP_Text _laughingText;
    [SerializeField] private TMP_Text _frightenedText;
    [SerializeField] private int _playerMultiplier;
    [SerializeField] private int _vampireMultiplier;
    public TMP_Text _playerScoreText;
    public TMP_Text _vampireScoreText;
    public int _playerScore;
    public int _vampireScore;
    private int _walkingCounter;
    private int _laughingCounter;
    private int _frightenedCounter;

    private void Start()
    {
        ResetScore();
        StartCoroutine(UpdateScore());
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameScene") return;

        UpdateCounter();

        _walkingText.text = "x" + _walkingCounter.ToString();
        _laughingText.text = "x" + _laughingCounter.ToString();
        _frightenedText.text = "x" + _frightenedCounter.ToString();
        _playerScoreText.text = _playerScore.ToString();
        _vampireScoreText.text = _vampireScore.ToString();
    }

    private IEnumerator UpdateScore()
    {
        yield return new WaitForSeconds(1);

        _playerScore += _laughingCounter * _playerMultiplier;
        _vampireScore += _frightenedCounter * _vampireMultiplier;

        StartCoroutine(UpdateScore());
    }

    private void UpdateCounter()
    {
        _walkingCounter = 0;
        _laughingCounter = 0;
        _frightenedCounter = 0;

        foreach (NPCInteraction npc in NPCs)
        {
            switch (npc.action)
            {
                case NPCInteraction.NPCAction.Walking:
                    _walkingCounter += 1; 
                    break;
                case NPCInteraction.NPCAction.Laughing:
                    _laughingCounter += 1; 
                    break;
                case NPCInteraction.NPCAction.Frightened:
                    _frightenedCounter += 1; 
                    break;
            }
        }
    }

    public void ResetScore()
    {
        _playerScore = 0;
        _vampireScore = 0;
    }
}
