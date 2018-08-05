using System;
using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Transform friendlyPylonPrefab;
    [SerializeField] private Transform enemyPylonPrefab;
    [SerializeField] private Transform friendlyPylonSpawnPosition;
    [SerializeField] private Transform enemyPylonSpawnPosition;

    [SerializeField] private GameObject levelCompleteScreen;

    public event EventHandler WaveStarts;

    private Scaler scaler = new Scaler();

    public Scaler Scaler
    {
        get { return this.scaler; }
    }

    private void Awake()
    {
        this.StartWave();
    }

    private void OnWaveStarts(EventArgs eventArgs)
    {
        var handler = WaveStarts;
        if (handler != null)
        {
            handler(this, eventArgs);
        }
    }

    private void StartWave()
    {
        this.OnWaveStarts(new EventArgs());
        GameObject.FindGameObjectWithTag("EnemyPylon").GetComponent<EntityHealth>().EntityDied += EnemyPylonDied;
        GameObject.FindGameObjectWithTag("FriendlyPylon").GetComponent<EntityHealth>().EntityDied += FriendlyPylonDied;
    }

    private void EnemyPylonDied(object sender, EventArgs e)
    {
        Debug.Log("You Won!");
        this.Scaler.IncreaseWave();
        this.levelCompleteScreen.SetActive(true);
        this.ClearRemainingEntities();
        this.RespawnPylons();
        StartCoroutine(this.RemoveOverlayAndStartNewWave());
    }

    private void FriendlyPylonDied(object sender, EventArgs e)
    {
        Debug.Log("You Lost!");
    }

    private void ClearRemainingEntities()
    {
        var minions = GameObject.FindGameObjectsWithTag("Minion");
        var monsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach (var minion in minions)
        {
            Destroy(minion);
        }

        foreach (var monster in monsters)
        {
            Destroy(monster);
        }
    }

    private void RespawnPylons()
    {
        var enemyPylon = GameObject.FindGameObjectWithTag("EnemyPylon");
        var friendlyPylon = GameObject.FindGameObjectWithTag("FriendlyPylon");
        if (enemyPylon != null)
        {
            Destroy(enemyPylon);
        }

        if (friendlyPylon != null)
        {
            Destroy(friendlyPylon);
        }

        Instantiate(this.friendlyPylonPrefab, this.friendlyPylonSpawnPosition.position,
            this.friendlyPylonSpawnPosition.rotation);
        Instantiate(this.enemyPylonPrefab, this.enemyPylonSpawnPosition.position,
            this.enemyPylonSpawnPosition.rotation);
    }

    private IEnumerator RemoveOverlayAndStartNewWave()
    {
        yield return new WaitForSeconds(2f);
        this.levelCompleteScreen.SetActive(false);
        yield return new WaitForSeconds(1f);
        this.StartWave();
    }
}