using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private PlayerController _player;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _coinsPerSecondsText;
    [SerializeField] private TMP_Text _attackDamageText;
    
    private double _coins;
    private double _coinsPerSeconds;
    

    private void Start() {
        _coins = 0;
        _coinsText.text = _coins.ToString();

        _player.SetAttackDamage(1);
        _attackDamageText.text = "Attack Damage " + _player.GetAttackDamage().ToString();
    }

    public void TapScreenButton() {
        // Damage on enemy
        Debug.Log("Tap..");
        _player.Attack();
    }
}
