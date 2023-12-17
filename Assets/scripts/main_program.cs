using System;
using System.Collections.Generic;
using UnityEngine;

public class AlienZoo : MonoBehaviour
{
    public GameObject[] creaturePrefabs;
    private List<Creature> creatures = new List<Creature>();

    void Start()
    {
        // Instantiate some creatures at random positions
        for (int i = 0; i < 10; i++)
        {
            GameObject creatureObject = Instantiate(creaturePrefabs[UnityEngine.Random.Range(0, creaturePrefabs.Length)], 
                                                    new Vector3(UnityEngine.Random.Range(-10f, 10f), 0, UnityEngine.Random.Range(-10f, 10f)), 
                                                    Quaternion.identity);
            Creature creature = creatureObject.GetComponent<Creature>();
            creatures.Add(creature);
            StartCoroutine(creature.BehaviorCoroutine());
        }
    }
}
