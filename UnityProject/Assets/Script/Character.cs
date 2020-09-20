using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 및 에너미가 공통으로 가지고 있는 요소를 관리하는 클래스
/// </summary>
public class Character : MonoBehaviour
{
    public float MaxHP;
    public float HP;

    public virtual void Hitted(Bullet bullet)
    {
        HP -= bullet.damage;

        if(HP < 0)
        {
            Destroy(gameObject);
        }
    }
}
