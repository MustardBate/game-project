using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomWalkParameters_", menuName = "PCG/RandomWalkData")]
public class RandomWalkSO : ScriptableObject
{
    public int iterations = 20, walkLength = 20;
    public bool startRandomlyEachIteration = true;
}
