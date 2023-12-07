using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSpawnerManager : MonoBehaviour
{
    GameObject[] clues;
    Transform[] initialPositions;
    Transform[] positionsAlreadySelected;
    void Start()
    {
        clues = GameObject.FindGameObjectsWithTag("Clue");

        for (int i = 0; i < clues.Length; i++)
        {

        }
    }


}
