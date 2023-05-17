using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class InputManager : MonoBehaviour, IInput
{
    public Vector3 Direction { get; private set; }

    public event Action<Vector3> OnDirectionChanged = delegate { };

    private void Start()
    {
        int random = Random.Range(0, 2);

        if (random == 0) Direction = Vector3.forward;
        else Direction = Vector3.right;

        IncrementGamesPlayed();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Direction.z == 1)
            {
                Direction = Vector3.right;
            }
            else
            {
                Direction = Vector3.forward;
            }

            OnDirectionChanged(Direction);
        }
    }

    private void IncrementGamesPlayed()
    {
        int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed");
        PlayerPrefs.SetInt("GamesPlayed", gamesPlayed + 1);
    }
}