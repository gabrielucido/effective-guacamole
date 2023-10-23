using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameModeController _gameModeController;
    private bool _levelCompleted = false;

    void Start()
    {
        _gameModeController = GetComponent<GameModeController>();
    }

    void Update()
    {
        if (_levelCompleted)
        {
            // TODO: Allow player to exit scene.
        }
    }
}