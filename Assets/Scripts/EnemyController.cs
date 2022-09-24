using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private List<GameObject> _enemies;

    private void Start() {
        _enemies[1].SetActive(true);
    }

    private void Death() {

    }

    public void TakeDamage() {
        var face = _enemies[1].transform.Find("face").gameObject;
        face.GetComponent<Animator>().SetTrigger("Take Damage");
    }
}
