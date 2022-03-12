using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _spawnPoints;

    private Transform[] _positions;
    private bool _isWorking;

    private void Start()
    {
        _isWorking = true;
        _positions = _spawnPoints.GetComponentsInChildren<Transform>();
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
