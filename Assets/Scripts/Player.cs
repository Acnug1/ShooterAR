using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _score = 0;
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public event UnityAction<int> ScoreAdded;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Hitted;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void AddScore()
    {
        _score++;
        ScoreAdded?.Invoke(_score); // вызываем событие ScoreAdded при добавлении очков
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        Hitted?.Invoke();

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}
