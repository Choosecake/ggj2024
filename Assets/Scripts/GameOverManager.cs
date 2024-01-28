using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    private NPCCounter _npcCounter;
    private SetGameOverSprite _gameOverSprite;

    private TMP_Text _playerScoreText;
    private TMP_Text _vampireScoreText;
    private int _playerScore;
    private int _vampireScore;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (_npcCounter == null) _npcCounter = FindObjectOfType<NPCCounter>();

        if (_npcCounter != null && SceneManager.GetActiveScene().name == "GameScene")
        {
            _playerScore = _npcCounter._playerScore;
            _vampireScore = _npcCounter._vampireScore;
        }

        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (_gameOverSprite == null) _gameOverSprite = GetComponent<SetGameOverSprite>();

            if (_playerScore > _vampireScore)
            {
                FindObjectOfType<NPCCounter>().gameObject.transform.GetChild(2).GetComponent<Image>().sprite = _gameOverSprite._winSprite;
                print(FindObjectOfType<NPCCounter>().gameObject.transform.GetChild(2).GetComponent<Image>().sprite);

            }
            else if (_vampireScore >= _playerScore)
            {
                FindObjectOfType<NPCCounter>().gameObject.transform.GetChild(2).GetComponent<Image>().sprite = _gameOverSprite._loseSprite;
            }

            _playerScoreText = FindObjectOfType<NPCCounter>().gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            _vampireScoreText = FindObjectOfType<NPCCounter>().gameObject.transform.GetChild(1).GetComponent<TMP_Text>();

            _playerScoreText.text = _playerScore.ToString();
            _vampireScoreText.text = _vampireScore.ToString();

            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
