using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="wave")]
public class waweconfig : ScriptableObject
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] GameObject point;
    [SerializeField] float timeBetweenSpawns=0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int nunberOfEnemy = 5;
    [SerializeField] float movespeed = 2f;


    public GameObject GetEnemyPrefab() { return enemyprefab; }
    public List<Transform> GetWayPoints()
    {
        var waveWAyPoints = new List<Transform>();
        foreach (Transform child in point.transform)
        {
            waveWAyPoints.Add(child);
        }
        return waveWAyPoints;
    }
    public float getTimeBetween() { return timeBetweenSpawns; }
    public float GetRandomSpawn() { return spawnRandomFactor; }
    public int GetNunberOfEnemy() { return nunberOfEnemy; }
    public float GetMoveSpeed() { return movespeed; }


}
