using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private SphereCollider _sphereCollider;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _spawner.SpawnRadius + _spawner.SpawnOffset; // прибавляем _spawner.SpawnOffset к _spawner.SpawnRadius, чтобы пули уничтожались на границе спавна врагов
    }
}
