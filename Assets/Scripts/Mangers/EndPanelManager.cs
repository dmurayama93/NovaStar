using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelManager : MonoBehaviour
{

    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _endPanel;
   void Start()
   {
        _endPanel.SetActive(false);
        if(_endPanel == null)
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

    }

    public void LoadLevel()
    {
        // Main Scene in GameDevHQ folder
        SceneManager.LoadScene(2);
    }

    public void LoadCheckpoint()
    {
        _spawnManager.SetStatus();
        _endPanel.SetActive(false);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }
}