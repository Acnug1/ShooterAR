using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    private Player _target;

    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void InitTarget(Player target)
    {
        _target = target;
    }

    public void Die()
    {
        Dying?.Invoke(this); // вызываем событие Dying и передаем Enemy, при смерти врага
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
