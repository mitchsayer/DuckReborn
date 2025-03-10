﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    public float score;

    public float speed = 0;

    public Transform destinationPos;
    public float despawnDistance;

    public float pathChangeDistance;
    public int pathIter = 0;
    public Vector3 tarPos;

    public bool isDead = false;

    public int m_ID { get; set; }

    private float GunForce = 100.0f;
    public Material notShotMaterial;
    public Material ShotMaterial;
    private Renderer _myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponentInChildren<Renderer>();
        SetMaterial(false);

    }

    // Update is called once per frame
    void Update()
    {
        //I like to move it, move it
        Move();

    }

    private void SetMaterial(bool shotAt)
    {
        if (notShotMaterial != null && ShotMaterial != null)
        {
            _myRenderer.material = shotAt ? ShotMaterial : notShotMaterial;
        }
    }
    public void Move()
    {
        //Get the direction to the path point
        Vector3 moveDir = (tarPos - transform.position).normalized;
        transform.LookAt(tarPos);
        transform.Rotate(new Vector3(0, 1, 0), -90);
        //Move along the position at the speed * deltaTime
        transform.position += moveDir * speed * Time.deltaTime;
 
    }
    public void OnPointerClick()
    {
        SetMaterial(true);
    }

    public bool NeedsPathPoint()
    {
        //Get the distance to the targetPosition
        float l_pathDistance = (tarPos - transform.position).magnitude;
        //If the distance is less than the minimum requirement return true
        if (l_pathDistance < pathChangeDistance)
            return true;
        
        //Other wise return false
        return false;
    }

    public bool TakeDamage(Vector3 a_dir)
    {
            Debug.Log("Hit");
        bool l_rtn = !isDead;
        //If were allowed to add points do it
        if (l_rtn)
        {
            Universe.Instance.Score += (int)score;
            //HingeJoint hjCom = GetComponentInChildren<HingeJoint>();
            //hjCom.gameObject.transform.GetComponent<Rigidbody>().AddForce(-a_dir * GunForce);
            isDead = true;
        }

        //Return that it was a successful hit
        return l_rtn;
    }

    public bool Despawn()
    {
        //Ge the distance the end
        float destDistance = (destinationPos.position - transform.position).magnitude;
        //If its within the required space..
        if (destDistance < despawnDistance)
            return true;
        return false;
    }
}
