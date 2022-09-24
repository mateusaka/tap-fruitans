using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {
    private double _coins;

    private void Start() {
        _coins = 0;

        GameEvents.CoinsChanged(_coins);
        GameEvents.AttackDamageChanged(1);
        GameEvents.LevelPassed();
    }

    public void TapScreenButton() {
        Debug.Log("Tap..");
        GameEvents.Attack();
    }
}
