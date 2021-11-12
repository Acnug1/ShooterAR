using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class HitScreen : MonoBehaviour
{
    [SerializeField] private Player _player;

    private CanvasGroup _hitScreenGroup;

    private void OnEnable()
    {
        _player.Hitted += OnHitted;
    }

    private void Start()
    {
        _hitScreenGroup = GetComponent<CanvasGroup>();
        _hitScreenGroup.alpha = 0;
    }

    private void OnDisable()
    {
        _player.Hitted -= OnHitted;
    }

    private void OnHitted()
    {
        StartCoroutine(HitPlayer()); // при попадания врага по игроку запускаем корутину
    }

    private IEnumerator HitPlayer()
    {
        _hitScreenGroup.alpha = 1; // запускаем экран попадания

        yield return null; // пропускаем кадр

        _hitScreenGroup.alpha = 0; // отключаем экран попадания
    }
}
