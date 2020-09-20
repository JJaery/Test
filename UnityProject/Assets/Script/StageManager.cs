using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region 싱글톤 패턴
    public static StageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StageManager>();
            }
            return _instance;
        }
    }
    private static StageManager _instance;
    #endregion

    public int CurrentStage { get; private set; }

    public GameObject enemyPrefab;

    public List<Enemy> currentEnemyList = new List<Enemy>();

    public void StartStage(int stage)
    {
        Debug.Log($"스테이지가 설정되었습니다. - {stage} 스테이지");
        CurrentStage = stage;
        MakeEnemies();
        ResetPlayerHP();
    }

    /// <summary>
    /// 적들이 사망했을 때 발동되는 메소드
    /// </summary>
    /// <param name="target">사망한 타겟</param>
    public void EnemyDown(Enemy target)
    {
        currentEnemyList.Remove(target);
        if(currentEnemyList.Count <= 0)
        {
            StartStage(++CurrentStage);
        }
    }

    private void ResetPlayerHP()
    {
        Player.Instance.HP = Player.Instance.MaxHP;
    }

    private void MakeEnemies()
    {
        for(int i = 0; i < CurrentStage * 10; i++)
        {
            Enemy target = SpawnManager.Instance.SpawnEnemy(enemyPrefab);
            currentEnemyList.Add(target);

            target.MaxHP = CurrentStage * 100;
            target.HP = target.MaxHP;
            target.AttackSpeed = 1 * Mathf.Log10(CurrentStage);

        }
    }
}
