using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private ParticleSystem _fireWeapon;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0) // если количество нажатий на тач больше 0 (количество пальцев на экране)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) // получаем нулевой тач (первое касание) и если его состояние равно: "палец коснулся тача"
            {
                Instantiate(_fireWeapon, _shootPoint.position, Quaternion.identity);
                Instantiate(_bulletTemplate, _shootPoint);
                _animator.SetTrigger("Shoot");
            }
        }
    }
}
