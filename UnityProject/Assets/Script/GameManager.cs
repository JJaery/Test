using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 싱글톤 패턴
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    private static GameManager _instance;
    #endregion

    public int score;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnClickStartToGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // AsyncOperation, AsyncOperation.isDone, AsyncOperation.progress
        yield return SceneManager.LoadSceneAsync(1);
        yield return null;
        StageManager.Instance.StartStage(1);
    }

}
