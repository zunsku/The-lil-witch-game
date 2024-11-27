using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressionCounter : MonoBehaviour
{
    [Header("Checks")]
    [SerializeField] public bool hasCloud;
    [SerializeField] public bool hasFairy;
    [SerializeField] public bool hasHerbs;
    [SerializeField] public bool hasBerries;
    [SerializeField] public bool hasCoins;
    void Start()
    {
        hasCloud = false;
        hasFairy = false;
        hasHerbs = false;
        hasBerries = false;
        hasCoins = false;
    }

    void Update()
    {
        
    }
}
