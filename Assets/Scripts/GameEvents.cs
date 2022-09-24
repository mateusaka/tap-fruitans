using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static Action<double> OnCoinsChanged;
    public static Action<double> OnAttackDamageChanged;
    public static Action<string> OnEnemyNameChanged;
    public static Action<double> OnEnemyHPChanged;
    public static Action<int> OnLevelChanged;
    public static Action OnLevelPassed;
    public static Action OnAttacked;
    public static Action<double> OnEnemyDamaged;
    public static Action OnGameStarted;
    public static Action OnEnemyDied;

    public static void CoinsChanged(double value) {
        if(OnCoinsChanged != null) {
            OnCoinsChanged(value);
        }
    }

    public static void AttackDamageChanged(double value) {
        if(OnAttackDamageChanged != null) {
            OnAttackDamageChanged(value);
        }
    }

    public static void EnemyNameChanged(string value) {
        if(OnEnemyNameChanged != null) {
            OnEnemyNameChanged(value);
        }
    }

    public static void EnemyHPChanged(double value) {
        if(OnEnemyHPChanged != null) {
            OnEnemyHPChanged(value);
        }
    }

    public static void LevelChanged(int value) {
        if(OnLevelChanged != null) {
            OnLevelChanged(value);
        }
    }

    public static void LevelPassed() {
        if(OnLevelPassed != null) {
            OnLevelPassed();
        }
    }

    public static void Attack() {
        if(OnAttacked != null) {
            OnAttacked();
        }
    }

    public static void EnemyDamaged(double value) {
        if(OnEnemyDamaged != null) {
            OnEnemyDamaged(value);
        }
    }

    public static void GameStarted() {
        if(OnGameStarted != null) {
            OnGameStarted();
        }
    }

    public static void EnemyDied() {
        if(OnEnemyDied != null) {
            OnEnemyDied();
        }
    }
}
