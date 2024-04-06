using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _spawnDelay;

    private void OnEnable()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_spawnDelay);
        int pointIndex;

        while (enabled)
        {
            pointIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_objectPrefab, _spawnPoints[pointIndex]);

            yield return wait;
        }
    }
}
