using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 플레이어의 공격을 담당하는 스크립트
/// </summary>
public class PlayerWeapon : MonoBehaviour
{
    public GameObject missilePrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GameObject target = Instantiate(missilePrefab);
            Bullet script = target.GetComponent<Bullet>();
            //script.owner = gameObject;
            script.ownerTag = gameObject.tag;
            target.transform.position = transform.position;
        }
    }
}
