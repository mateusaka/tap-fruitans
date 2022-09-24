using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _attackDamageText;
    [SerializeField] private TMP_Text _enemyNameText;
    [SerializeField] private TMP_Text _enemyHPText;
    [SerializeField] private TMP_Text _levelText;

    private void OnEnable() {
        GameEvents.OnCoinsChanged += UpdateCoins;
        GameEvents.OnAttackDamageChanged += UpdateAtackDamage;
        GameEvents.OnEnemyNameChanged += UpdateEnemyName;
        GameEvents.OnEnemyHPChanged += UpdateEnemyHP;
        GameEvents.OnLevelChanged += UpdateLevel;
    }

    private void OnDisable() {
        GameEvents.OnCoinsChanged -= UpdateCoins;
        GameEvents.OnAttackDamageChanged -= UpdateAtackDamage;
        GameEvents.OnEnemyNameChanged -= UpdateEnemyName;
        GameEvents.OnEnemyHPChanged -= UpdateEnemyHP;
        GameEvents.OnLevelChanged -= UpdateLevel;
    }

    private void UpdateCoins(double value) {
        _coinsText.text = value.ToString();
    }

    private void UpdateAtackDamage(double value) {
        _attackDamageText.text = "Attack Damage " + value;
    }

    private void UpdateEnemyName(string value) {
        _enemyNameText.text = value;
    }

    private void UpdateEnemyHP(double value) {
        _enemyHPText.text = value + " HP";
    }

    private void UpdateLevel(int value) {
        _levelText.text = "Level " + value;
    }
}
