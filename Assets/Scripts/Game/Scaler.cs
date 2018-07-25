using UnityEngine;
using System.Collections;
using Mathf = UnityEngine.Mathf;

public class Scaler
{
    public int WaveNumber { get; private set; }

    #region Pylons

    public float FriendlyPylonHealth { get; private set; }
    public float EnemyPylonHealth { get; private set; }

    #endregion

    #region Monster

    public float MonsterHealth { get; private set; }
    public float MonsterAttackSpeed { get; private set; }
    public float MonsterAttackDamage { get; private set; }
    public float MonsterAttackRange { get; private set; }

    public int MonsterCount { get; private set; }

    #endregion

    #region Monster

    public float MinionHealth { get; private set; }
    public float MinionAttackSpeed { get; private set; }
    public float MinionAttackDamage { get; private set; }
    public float MinionAttackRange { get; private set; }

    public int MinionCount { get; private set; }

    #endregion

    public Scaler()
    {
        this.InitializeStats();
    }

    private void InitializeStats()
    {
        this.WaveNumber = 1;
        this.FriendlyPylonHealth = 200;
        this.EnemyPylonHealth = 200;

        this.MonsterHealth = 50;
        this.MonsterAttackDamage = 5;
        this.MonsterAttackRange = 3;
        this.MonsterAttackSpeed = 1;
        this.MonsterCount = 4;

        this.MinionHealth = 100;
        this.MinionAttackDamage = 5;
        this.MinionAttackRange = 3;
        this.MinionAttackSpeed = 1;
        this.MinionCount = 6;
    }

    public void IncreaseWave()
    {
        this.WaveNumber++;

        this.EnemyPylonHealth += this.WaveNumber;
        this.MonsterHealth = 50 + this.WaveNumber * this.WaveNumber;
        this.MonsterAttackDamage = 5 + this.WaveNumber * this.WaveNumber;
    }
}