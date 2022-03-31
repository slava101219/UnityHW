using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private int _speed;

    private int _xCoordinateTarget = 18;
    private Transform _transform;
    private Vector3 _targetVector;

    void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(Moving(_transform));
    }

    private IEnumerator Moving(Transform transform)
    {
        _targetVector = new Vector3(17, 0, 70);

        while (transform.position.x > _xCoordinateTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetVector , Time.deltaTime * _speed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
