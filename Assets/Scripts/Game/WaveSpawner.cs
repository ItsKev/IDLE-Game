using System;
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform minionPrefab;
    [SerializeField] private Transform monsterPrefab;
    [SerializeField] private Transform minionSpawn;
    [SerializeField] private Transform monsterSpawn;

    private int minionCount = 10;
    private int monsterCount = 4;

    private Scaler scaler;

    private void Awake()
    {
        var gameHandler = this.gameObject.GetComponent<GameHandler>();
        gameHandler.WaveStarts += StartSpawningWave;
        this.scaler = gameHandler.Scaler;
    }

    private void StartSpawningWave(object sender, EventArgs e)
    {
        this.minionCount = scaler.MinionCount;
        this.monsterCount = scaler.MonsterCount;
        StartCoroutine(SpawnMinions());
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMinions()
    {
        for (var i = 0; i < this.minionCount; i++)
        {
            Instantiate(this.minionPrefab, this.minionSpawn.position, this.minionSpawn.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator SpawnMonsters()
    {
        for (var i = 0; i < this.monsterCount; i++)
        {
            Instantiate(this.monsterPrefab, this.monsterSpawn.position, this.monsterSpawn.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
