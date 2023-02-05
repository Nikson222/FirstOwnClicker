using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawScript : MonoBehaviour
{
    private GameObject _planet;
    [SerializeField] GameObject _planetPrefab;

    public float SpawnTime;
    private float _spawnTime;

    void Awake()
    {
        _spawnTime = SpawnTime;
        _planet = GameObject.FindGameObjectWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        if (_planet == null && _spawnTime <= 0)
        {
            Instantiate(_planetPrefab, transform.position, Quaternion.identity);
            _planet = GameObject.FindGameObjectWithTag("Planet");
            _spawnTime = SpawnTime;
            //StopCoroutine(waitSpawnTime());
        }
        else if (_planet == null && _spawnTime > 0)
        {
            _spawnTime -= Time.deltaTime;
        }
    }
}
