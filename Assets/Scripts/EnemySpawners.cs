using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemySpawners;

    private Transform[] _positions;
    private bool _isWorking;

    private void Start()
    {
        _isWorking = true;
        _positions = _enemySpawners.GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2);

        while (_isWorking)
        {
            Instantiate(_enemy, _positions[Random.Range(1, _positions.Length)].position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
