using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _additionalScale;
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionnalScale = 0.5f;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionnalScale + _additionalScale /2f;
    private void Awake()
    {
        Build();
    }

    private void Build()
    {
      GameObject beam =  Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, beam.transform);
        for(int i=0; i<_levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0,_platform.Length)],ref spawnPosition,beam.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    } 

    private void SpawnPlatform(Platform platform,ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(-90, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
