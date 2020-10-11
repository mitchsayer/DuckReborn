using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public Duck m_prefab;
    public float m_speed;
    public float m_spawnInterval;
    public float m_reachingDistance;
    public Vector3[] m_path;

    private float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_timer <= 0)
        {
            SpawnDuck();
            m_timer = m_spawnInterval;
        }
        else
        {
            m_timer -= Time.deltaTime;
        }
    }

    void SpawnDuck()
    {
        Duck l_duck = Instantiate(m_prefab, new Vector3(0, 0, 0), new Quaternion(), transform);
        l_duck.Speed = m_speed;
            l_duck._path = m_path;
        for(int i = 0; i < m_path.Length; i++)
        {
            l_duck._path[i] =  m_path[i] + transform.position; 

        }
        l_duck.ReachingDistance = m_reachingDistance;
    }
}
