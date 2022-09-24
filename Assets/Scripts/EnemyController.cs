using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Image _HPBar;
    [SerializeField] private double _defaultEnemyHP;

    private double _currentHP;
    private double _maxHP;
    private int _enemyIndex = 0;

    private void OnEnable() {
        GameEvents.OnEnemyDamaged += TakeDamage;
        GameEvents.OnEnemyDied += Death;
        GameEvents.OnLevelChanged += SetEnemy;
    }

    private void OnDisable() {
        GameEvents.OnEnemyDamaged -= TakeDamage;
        GameEvents.OnEnemyDied -= Death;
        GameEvents.OnLevelChanged -= SetEnemy;
    }

    private void SetEnemy(int level) {
        Debug.Log("set enemy");
        _currentHP = _defaultEnemyHP * level;
        _maxHP = _currentHP;
        _HPBar.fillAmount = 1;

        _enemyIndex = Random.Range(0, _enemies.Count);
        _enemies[_enemyIndex].SetActive(true);

        GameEvents.EnemyHPChanged(_currentHP);
        GameEvents.EnemyNameChanged(_enemies[_enemyIndex].name);
    }

    private void Death() {
        _enemies[_enemyIndex].SetActive(false);
    }

    public void TakeDamage(double value) {
        Debug.Log("valor dano " + value);
        Debug.Log("current hp " + _currentHP);
        _currentHP -= value;
        Debug.Log("current hp " + _currentHP);
        _HPBar.fillAmount = (float)(_currentHP / _maxHP);

        GameEvents.EnemyHPChanged(_currentHP);

        var face = _enemies[_enemyIndex].transform.Find("face").gameObject;
        face.GetComponent<Animator>().SetTrigger("Take Damage");

        if(_currentHP <= 0) {
            GameEvents.EnemyDied();
            GameEvents.LevelPassed();
        }
    }
}
