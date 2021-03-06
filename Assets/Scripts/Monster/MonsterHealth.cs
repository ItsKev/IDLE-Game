﻿using UnityEngine;
using System.Collections;

public class MonsterHealth : EntityHealth
{
    protected override void Awake()
    {
        base.Awake();
        var scaler = EntityHealth.gameHandler.Scaler;
        this.startingHealth = scaler.MonsterHealth;
    }
}
