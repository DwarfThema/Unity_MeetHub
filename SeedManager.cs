using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public string GameSeed = "Default";
    public int CurrentSeed = 0;

    private void Start()
    {
        GameSeed = GameManager.Instance.username;
        CurrentSeed = GameSeed.GetHashCode();
        Random.InitState(CurrentSeed);
    }
}
