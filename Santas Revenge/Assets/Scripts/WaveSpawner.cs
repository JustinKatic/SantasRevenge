using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string m_name;
        public Transform[] m_enemy;
        public float m_rate;
    }

    [SerializeField] int m_nextWaveNum;

    [SerializeField] GameObject[] spawnPoints;

    [Header("WAVE DETAILS")]
    [SerializeField, NonReorderable] Wave[] m_waves;
    private int m_currentEnemy = 0;
    private float m_searchCountdown = 1f;

    [SerializeField] float m_timeBetweenWaves = 5f;
    private float m_waveCountdown;

    public WaveDataSO waveDataSO;

    //  [Header("EVENTS")]
    //  [SerializeField] GameEvent m_waveCompletedEvent;
    // [SerializeField] GameEvent m_allWavesCompleted;


    //  [Header("UI TEXT")]
    // [SerializeField] TextMeshProUGUI m_waveCounterTxt;
    // [SerializeField] TextMeshProUGUI m_currentWaveTxt;






    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        //   m_currentWaveTxt.text = m_waves[m_nextWaveNum].m_name;
        waveDataSO.ActiveEnemies = 0;
        m_waveCountdown = m_timeBetweenWaves;
    }

    void Update()
    {
        if (State == SpawnState.WAITING)
        {
            if (StartNextWave())
            {
                m_currentEnemy = 0;
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (m_waveCountdown <= 0)
        {
            if (State != SpawnState.SPAWNING)
            {
                //   m_waveCounterTxt.text = string.Empty;
                StartCoroutine(SpawnWave(m_waves[m_nextWaveNum]));
            }
        }

        else
        {
            m_waveCountdown -= Time.deltaTime;
            //  m_waveCounterTxt.text = Mathf.Round(m_waveCountdown).ToString();
        }
    }


    void WaveCompleted()
    {
        State = SpawnState.COUNTING;
        m_waveCountdown = m_timeBetweenWaves;


        if (m_nextWaveNum + 1 == m_waves.Length)
        {
            Debug.Log("all waves complete");
        }
        else
        {
            m_nextWaveNum++;
            waveDataSO.ActiveEnemies = 0;
            //    m_currentWaveTxt.text = m_waves[m_nextWaveNum].m_name;
            Debug.Log("Waves complete");
        }
    }

    bool StartNextWave()
    {
        m_searchCountdown -= Time.deltaTime;
        if (m_searchCountdown <= 0f)
        {
            m_searchCountdown = 1f;

            if (waveDataSO.ActiveEnemies <= 0)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        State = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.m_enemy.Length; i++)
        {
            SpawnEnemy(_wave.m_enemy[i]);
            yield return new WaitForSeconds(_wave.m_rate);
        }

        State = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform a_enemy)
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length - 1);
        Transform _sp = spawnPoints[randSpawnPoint].transform;

        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(a_enemy.tag);
        enemy.transform.position = _sp.transform.position;
        enemy.transform.rotation = _sp.transform.rotation;
        enemy.SetActive(true);
        waveDataSO.ActiveEnemies += 1;

        m_currentEnemy++;
        if (m_currentEnemy >= spawnPoints.Length)
            m_currentEnemy = 0;
    }
}