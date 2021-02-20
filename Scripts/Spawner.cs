using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnOffset;
    [SerializeField] private int _enemyCount;

    public float SpawnRadius => _spawnRadius;
    public float SpawnOffset => _spawnOffset;

    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            if (_spawnCount < _enemyCount) // если количество заспавненных врагов меньше заданного количество врагов в волне
            {
                Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], GetRandomPlaceInSphere(_spawnRadius), Quaternion.identity);
                Vector3 lookDirection = _target.transform.position - newEnemy.transform.position; // получаем направление куда смотреть врагу
                newEnemy.transform.rotation = Quaternion.LookRotation(lookDirection); // задаем поворот взгляда для врага
                newEnemy.InitTarget(_target);
                newEnemy.Dying += OnEnemyDying; // подписываем на событие OnEnemyDying при создании врага
                _spawnCount++;
            }
            else // если все указанные в волне противники заспавнились, пропускаем время 2 раза подряд для передышки игрока
            {
                _spawnCount = 0;
            }

            yield return waitForSeconds;
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying; // отписываемся события OnEnemyDying при смерти врага

        _target.AddScore(); // прибавляем очки игроку
    }

    private Vector3 GetRandomPlaceInSphere(float radius)
    {
        return _spawnOffset * Vector3.one + Random.insideUnitSphere * radius; // возвращает случайную точку в сфере, начиная со _spawnOffset до указанного радиуса сферы
    }
}
