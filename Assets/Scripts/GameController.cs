using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private TMP_Text _coinsText;
    private double _coins;
    [SerializeField] private TMP_Text _coinsPerSecondsText;
    private double _coinsPerSeconds;

    private void Start() {
        _coins = 0;
        _coinsText.text = _coins.ToString();
    }

    public void TapScreenButton() {
        // Damage on enemy
        Debug.Log("Tap..");
    }
}
