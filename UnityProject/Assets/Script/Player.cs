using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 상태 및 수치 관리 스크립트
/// </summary>
public class Player : Character
{
    #region 싱글톤 패턴
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();
            }
            return _instance;
        }
    }
    private static Player _instance;
    #endregion


    public PlayerMovement movementScript;
    public PlayerWeapon weaponScript;
}
