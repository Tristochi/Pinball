using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    private GameState state;
    
    void Awake()
    {
        GameManager.OnGameStateChanged += GMOnGameStateChanged;
    }

    void onDestroy()
    {
        GameManager.OnGameStateChanged -= GMOnGameStateChanged;
    }
    
    private void GMOnGameStateChanged(GameState obj)
    {
        state = obj;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.UpdateGameState(GameState.Playing);
        }
    }
}
