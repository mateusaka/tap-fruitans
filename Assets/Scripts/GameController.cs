using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    // Currency
    private double _coins;

    // Player
    [Header("Player")]
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private string _playerAttackName;
    private int _level;
    private double _tapAttackDamage;

    // Enemies
    [Header("Enemies")]
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private double _defaultEnemyHP = 15d;
    private double _enemyCurrentHP;
    private double _enemyMaxHP;
    private int _enemyIndex;

    // Upgrade
    private double _tapUpgradeCost;
    private int _tapUpgradeLevel;

    // UI
    [Header("UI")]
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _tapAttackDamageText;
    [SerializeField] private Image _enemyHPBarImage;
    [SerializeField] private TMP_Text _enemyNameText;
    [SerializeField] private TMP_Text _enemyHPText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _tapUpgradeCostText;
    [SerializeField] private TMP_Text _tapUpgradeLevelText;
    [SerializeField] private Button _tapUpgradeButton;

    private void Start() {
        Load();

        //_coins = 0;
        _coinsText.text = _coins.ToString();
        //_level = 1;
        _levelText.text = "Level " + _level;
        //_tapAttackDamage = 1;
        _tapAttackDamageText.text = "Tap Attack Damage " + _tapAttackDamage;
        //_tapUpgradeLevel = 1;
        _tapUpgradeLevelText.text = "Lv. " + _tapUpgradeLevel;

        SetEnemy();
        CheckUpgradeInteractableButton();
    }

    #region SAVE_LOAD
    private void Load() {
        _coins = StringToDouble(PlayerPrefs.GetString("_coins", "0"));
        _level = PlayerPrefs.GetInt("_level", 1);
        _tapAttackDamage = StringToDouble(PlayerPrefs.GetString("_tapAttackDamage", "1"));
        _tapUpgradeLevel = PlayerPrefs.GetInt("_tapUpgradeLevel", 1);

        #if UNITY_EDITOR
        Debug.Log("Loaded");
        #endif
    }

    private void Save() {
        PlayerPrefs.SetString("_coins", DoubleToString(_coins));
        PlayerPrefs.SetInt("_level", _level);
        PlayerPrefs.SetString("_tapAttackDamage", DoubleToString(_tapAttackDamage));
        PlayerPrefs.SetInt("_tapUpgradeLevel", _tapUpgradeLevel);

        #if UNITY_EDITOR
        Debug.Log("Saved");
        #endif
    }

    private string DoubleToString(double value) {
        return value.ToString();
    }

    private double StringToDouble(string value) {
        if(string.IsNullOrEmpty(value)) {
            return 0d;
        }

        return double.Parse(value);
    }

    /* private void OnApplicationFocus(bool focusStatus) {
        Save();
    } */

    private void OnApplicationQuit() {
        Save();
    }
    #endregion

    #region GAME_SYSTEM
    public void TapScreenButton() {
        Attack();
    }

    private void NextLevel() {
        _level += 1;
        _levelText.text = "Level " + _level;
    }
    #endregion

    #region PLAYER
    public void Attack() {
        _playerAnimator.SetTrigger(_playerAttackName);

        EnemyTakeDamage();
    }
    #endregion

    #region ENEMY
    private void SetEnemy() {
        _enemyCurrentHP = _defaultEnemyHP * _level;
        _enemyHPText.text = _enemyCurrentHP + " HP";

        _enemyMaxHP = _enemyCurrentHP;
        _enemyHPBarImage.fillAmount = 1;

        _enemyIndex = Random.Range(0, _enemies.Count);
        _enemies[_enemyIndex].SetActive(true);
        _enemyNameText.text = _enemies[_enemyIndex].name;
    }

    private void EnemyDeath() {
        _enemies[_enemyIndex].SetActive(false);

        EnemyDropCoins();
        NextLevel();
        SetEnemy();
    }

    public void EnemyTakeDamage() {
        _enemyCurrentHP -= _tapAttackDamage;
        _enemyHPText.text = _enemyCurrentHP + " HP";
        _enemyHPBarImage.fillAmount = (float)(_enemyCurrentHP / _enemyMaxHP);

        var face = _enemies[_enemyIndex].transform.Find("face");
        if(face == null) {
            var faceL = _enemies[_enemyIndex].transform.Find("face-left");
            var faceR = _enemies[_enemyIndex].transform.Find("face-right");

            faceL.GetComponent<Animator>().SetTrigger("Take Damage");
            faceR.GetComponent<Animator>().SetTrigger("Take Damage");
        }
        else {
            face.GetComponent<Animator>().SetTrigger("Take Damage");
        }

        /* var face = .transform.Find("face").gameObject.GetComponent<Animator>();
        if(face == null) {
            var faceL = _enemies[_enemyIndex].transform.Find("face-left").gameObject.GetComponent<Animator>();
            var faceR = _enemies[_enemyIndex].transform.Find("face-right").gameObject.GetComponent<Animator>();

            faceL.SetTrigger("Take Damage");
            faceR.SetTrigger("Take Damage");
        }
        else {
            face.SetTrigger("Take Damage");
        } */

        if(_enemyCurrentHP <= 0) {
            EnemyDeath();
        }
    }

    private void EnemyDropCoins() {
        _coins += _level * 6;
        _coinsText.text = _coins.ToString();

        CheckUpgradeInteractableButton();
    }
    #endregion

    #region UPGRADES
    private void CheckUpgradeInteractableButton() {
        _tapUpgradeCost = _tapUpgradeLevel * 9;
        _tapUpgradeCostText.text = _tapUpgradeCost.ToString();

        if(_tapUpgradeCost > _coins) {
            _tapUpgradeButton.interactable = false;
        }
        else {
            _tapUpgradeButton.interactable = true;
        }        
    }

    public void TapUpgradeButton() {
        _tapUpgradeCost = _tapUpgradeLevel * 9;

        if(_tapUpgradeCost > _coins) {
            return;
        }

        _tapUpgradeLevel += 1;
        _tapUpgradeLevelText.text = "Lv. " + _tapUpgradeLevel;
        _coins -= _tapUpgradeCost;
        _coinsText.text = _coins.ToString();
        _tapAttackDamage += 2;
        _tapAttackDamageText.text = "Tap Attack Damage " + _tapAttackDamage;

        CheckUpgradeInteractableButton();
    }
    #endregion
}
