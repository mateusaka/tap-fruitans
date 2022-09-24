using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attack;
    [SerializeField] private EnemyController _enemy;
    private double _attackDamage;

    public void SetAttackDamage(double value) {
        _attackDamage = value;
    }

    public double GetAttackDamage() {
        return _attackDamage;
    }

    public void Attack() {
        _animator.SetTrigger(_attack);

        _enemy.TakeDamage();
    }
}
