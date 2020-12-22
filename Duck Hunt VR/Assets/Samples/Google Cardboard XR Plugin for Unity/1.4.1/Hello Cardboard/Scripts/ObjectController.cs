//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    //introducing Gunhandling
    public GameObject HandPos, Gun, Hand;
    private bool hasGun;

    //Duck Script

    //public float score;

    //public float speed = 0;

    //public Transform destinationPos;
    //public float despawnDistance;

    //public float pathChangeDistance;
    //public int pathIter = 0;
    //public Vector3 tarPos;

    //public bool isDead = false;

    //public int m_ID { get; set; }

    //private float GunForce = 100.0f;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Awake()
    {
        hasGun = false;
    }
    public void Start()
    {
        _startingPosition = transform.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    ///// <summary>
    ///// Teleports this instance randomly when triggered by a pointer click.
    ///// </summary>
    //public void TeleportRandomly()
    //{
    //    // Picks a random sibling, moves them somewhere random, activates them,
    //    // deactivates ourself.
    //    int sibIdx = transform.GetSiblingIndex();
    //    int numSibs = transform.parent.childCount;
    //    sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
    //    GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

    //    // New object's location.
    //    float angle = Random.Range(-90, 90);
    //    float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
    //    float height = Random.Range(_minObjectHeight, _maxObjectHeight);
    //    Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
    //                                 Mathf.Sin(angle) * distance);
    //    randomSib.transform.localPosition = newPos;

    //    randomSib.SetActive(true);
    //    gameObject.SetActive(false);
    //    SetMaterial(false);
    //}

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        PickupGun();
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
    public void PickupGun()
    {
        Hand.transform.rotation = new Quaternion(0, 0, 45, -45);
        Gun.transform.parent = HandPos.transform;
        Gun.transform.localPosition = new Vector3(0, 0, 0);
        Gun.transform.rotation = new Quaternion(0, 0, 0, 0);
        Gun.transform.localScale = new Vector3(1, 1, 1);

        hasGun = true;
        Universe.Instance.HasGun = hasGun;
        Universe.Instance.GameState = 1;
    }
    //public bool TakeDamage(Vector3 a_dir)
    //{
    //    Debug.Log("Hit");
    //    bool l_rtn = !isDead;
    //    //If were allowed to add points do it
    //        if (l_rtn)
    //    {
    //        Universe.Instance.Score += (int)score;
    //        HingeJoint hjCom = GetComponentInChildren<HingeJoint>();
    //        hjCom.gameObject.transform.GetComponent<Rigidbody>().AddForce(-a_dir * GunForce);
    //        isDead = true;
    //    }
    //        //Return that it was a successful hit
    //        return l_rtn;
    //    }

}

