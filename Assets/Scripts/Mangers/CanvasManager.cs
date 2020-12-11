using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _endPanel;
    private Button _checkPointButton;
    private PlayerHealthAndDamage _player;
    private SpawnManager _spawnManager;
    private Text _winText;
    private Text _diedText;
    private bool _playerDead;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerHealthAndDamage>();
        if (_player == null)
        {
            Debug.Log("Missing Player Health");
        }

        if (_endPanel == null)
        {
            Debug.Log("Missing end panel");
        }

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("Cant find spawn manager");
        }
    }
    void Update()
    {
        CheckEndPanelStatus();
        CheckWinStatus();
    }

    void CheckEndPanelStatus()
    {
        if (!_player.getPlayerStatus())
        {
            _endPanel.SetActive(true);
            _playerDead = true;
            _diedText = GameObject.Find("Died_Text").GetComponent<Text>();
            _diedText.enabled = true;
            if (_spawnManager.GetCheckPointStatus())
            {
                _checkPointButton = GameObject.Find("Checkpoint_Button").GetComponent<Button>();
                _checkPointButton.interactable = true;
            }
        }
        else
        {
            _endPanel.SetActive(false);
        }
    }

    void CheckWinStatus()
    {
        if (_spawnManager.DidWin()  && _playerDead == false)
        {
            _endPanel.SetActive(true);
            _winText = GameObject.Find("Win_Text").GetComponent<Text>();
            _winText.enabled = true;
        }
    }
}
