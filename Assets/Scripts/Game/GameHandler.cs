using System;
using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    public event EventHandler WaveStarts;
    public event EventHandler StatsChanged;

    public Scaler Scaler { get; private set; }

    private void Awake()
    {
        this.OnWaveStarts(new EventArgs());
        GameObject.FindGameObjectWithTag("EnemyPylon").GetComponent<EntityHealth>().EntityDied += EnemyPylonDied;
        GameObject.FindGameObjectWithTag("FriendlyPylon").GetComponent<EntityHealth>().EntityDied += FriendlyPylonDied;
    }

    private void OnWaveStarts(EventArgs eventArgs)
    {
        var handler = WaveStarts;
        if (handler != null)
        {
            handler(this, eventArgs);
        }
    }

    private void EnemyPylonDied(object sender, EventArgs e)
    {
        Debug.Log("You Won!");
    }

    private void FriendlyPylonDied(object sender, EventArgs e)
    {
        Debug.Log("You Lost!");
    }
}