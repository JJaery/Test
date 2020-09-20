using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region 싱글톤 패턴
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpawnManager>();
            }
            return _instance;
        }
    }
    private static SpawnManager _instance;
    #endregion

    public BoxCollider2D spawnArea;


    public Enemy SpawnEnemy(GameObject prefab)
    {
        if (prefab.GetComponent<Enemy>() == null)
        {
            Debug.LogError("Enemy 스크립트를 찾을 수 없는 오브젝트를 생성 시도하였습니다.");
            return null;
        }
        else
        {
            GameObject obj = Instantiate(prefab); // 프리팹 복사해서 씬에다 오브젝트 생성
            obj.transform.position = GetSpawnPosition();
            Enemy script = obj.GetComponent<Enemy>();
            return script;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        float minX = spawnArea.transform.position.x - spawnArea.size.x * 0.5f; 
        float maxX = spawnArea.transform.position.x + spawnArea.size.x * 0.5f;

        float minY = spawnArea.transform.position.y - spawnArea.size.y * 0.5f;
        float maxY = spawnArea.transform.position.y + spawnArea.size.y * 0.5f;

        float randomX = Random.Range(minX, maxX); // 렌덤 X값
        float randomY = Random.Range(minY, maxY); // 렌덤 Y값

        return new Vector2(randomX, randomY);
    }
}
