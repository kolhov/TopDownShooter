using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private bool looping;

    private int _startingWave = 0;
    [SerializeField] private int numberOfEnemiesAlive;

    public void SubtractEnemy()
    {
        numberOfEnemiesAlive--;
    }
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = _startingWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemies(currentWave));
        }

        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            numberOfEnemiesAlive++;
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitUntil(() => numberOfEnemiesAlive <= 0);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SceneChanger>().LoadNextLevel();
    }

}
