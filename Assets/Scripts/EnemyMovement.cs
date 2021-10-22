using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField]private Transform _centerTarget;

    private Vector3 _normal;
    private bool _isMoove;
    private int _framePerSecond;

    private void Awake()
    {
        Debug.Log(_centerTarget.position);
        _isMoove = true;
    }

    private void Start()
    {
        SetStartRotation();
        StartCoroutine(Turn());
    }

    private void Update()
    {
        transform.position += Project() * Time.deltaTime * _speed;
        _framePerSecond = (int)(1 / Time.deltaTime);
    }

    private Vector3 Project()
    {
        return transform.forward - Vector3.Dot(transform.forward, _normal) * _normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Terrain terrain))
        {
            _normal = collision.contacts[0].normal;
        }

        if (collision.collider.GetComponent<Wall>())
        {
            transform.eulerAngles -= new Vector3(0, 180, 0);
        }
    }

    private IEnumerator Turn()
    {
        int[] directions = { 1, -1 };
        int forceOfChange = Random.Range(30, 100);
        int time = 2;

        while (_isMoove)
        {
            int direction = directions[Random.Range(0, directions.Length)];

            for (int i = 0; i < time * _framePerSecond; i++)
            {                
                transform.eulerAngles += new Vector3(0, forceOfChange * Time.deltaTime * direction, 0);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void SetStartRotation()
    {
        Vector3 vectorDifference = _centerTarget.position - transform.position;
        float angle = Vector3.Angle(vectorDifference, transform.forward);

        if (vectorDifference.x < 0)
            angle *= -1;

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + angle, 0);
    }

}