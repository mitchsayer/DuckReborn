using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{

    private float m_speed;
    public float Speed { get { return m_speed; } set { m_speed = value; } }

    private float m_reachingDistance;
    public float ReachingDistance {  get { return m_reachingDistance; } set { m_reachingDistance = value; } }

    public Vector3[] _path;

    private Vector3 m_moveTarget;
    private int m_moveTarIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Move if there is a target and a speed set
        if (m_moveTarget != new Vector3(0, 0, 0) && m_speed != 0)
            transform.position += m_speed * (m_moveTarget - transform.position) * Time.deltaTime;

     

        if (_path.Length > 0)
        { 
            //If duck has reached the target with in a reaching distance
        
            if (Vector3.Distance(m_moveTarget, transform.position) < m_reachingDistance)
        
            {
              //..And duck has not found the end
                if (m_moveTarIndex < _path.Length - 1)
                    //Go to the next target
                    m_moveTarIndex++;
                //else
                    //..otherwise destroy the duck
                  //  Destroy(this);

            }

            m_moveTarget = _path[m_moveTarIndex];
        }
    }
}
