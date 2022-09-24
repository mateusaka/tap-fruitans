using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attackName;
    private int _level = 0;
    private double _baseAttackDamage = 1;
    private double _tapAttackDamage = 0;

    private void OnEnable() {
        GameEvents.OnLevelPassed += NextLevel;
        GameEvents.OnAttacked += Attack;
    }

    private void OnDisable() {
        GameEvents.OnLevelPassed -= NextLevel;
        GameEvents.OnAttacked -= Attack;
    }

    private void NextLevel() {
        _level += 1;

        GameEvents.LevelChanged(_level);        
    }

    public void Attack() {
        _animator.SetTrigger(_attackName);

        double formula = (_baseAttackDamage + _tapAttackDamage);

        GameEvents.EnemyDamaged(formula);
    }
}
