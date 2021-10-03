using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _spawners;

    private Transform[] _positions;
    private bool _isWorking;

    private void Start()
    {
        _isWorking = true;
        _positions = _spawners.GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isWorking)
        {
            Instantiate(_enemy, _positions[Random.Range(1, _positions.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
