using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    [SerializeField] private PlayerController _player;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Image _HPBar;
    [SerializeField] private double _defaultEnemyHP;
    [SerializeField] private TMP_Text _enemyNameText;
    [SerializeField] private TMP_Text _enemyHPText;
    private double _currentHP;
    private double _maxHP;
    private int _level = 0;
    private int _enemyIndex = 0;

    private void Start() {
        NextLevel();
        InstantiateRandomEnemy();
    }

    private void InstantiateRandomEnemy() {
        _enemyIndex = Random.Range(0, _enemies.Count);
        _enemies[_enemyIndex].SetActive(true);
        _enemyNameText.text = _enemies[_enemyIndex].name;
    }

    private void NextLevel() {
        _level++;
        _currentHP = _defaultEnemyHP * _level;
        _enemyHPText.text = _currentHP + " HP";
        _maxHP = _currentHP;
        _HPBar.fillAmount = 1;
    }

    private void Death() {
        _enemies[_enemyIndex].SetActive(false);

        NextLevel();
        InstantiateRandomEnemy();
    }

    public void TakeDamage() {
        _currentHP -= _player.GetAttackDamage();
        _HPBar.fillAmount = (float)(_currentHP / _maxHP);
        _enemyHPText.text = _currentHP + " HP";

        var face = _enemies[_enemyIndex].transform.Find("face").gameObject;
        face.GetComponent<Animator>().SetTrigger("Take Damage");

        if(_currentHP <= 0) {
            Death();
        }
    }
}
