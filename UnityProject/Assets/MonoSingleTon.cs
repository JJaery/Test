using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : Object
{
    #region 싱글톤 패턴
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
            }
            return _instance;
        }
    }
    private static T _instance;
    #endregion
}