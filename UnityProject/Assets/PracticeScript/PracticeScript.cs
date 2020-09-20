using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PracticeScript : MonoBehaviour
{
    /// <summary>
    /// Start랑 똑같은데 Start보다 앞단에서 한번만 실행됨.
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake 발동");
    }
    /// <summary>
    /// 스크립트가 활성화 되고 첫 프레임에서 실행
    /// </summary>
    private void Start()
    {
        Debug.Log("Start 발동");
    }

    /// <summary>
    /// 스크립트가 활성화 되는 도중 매 프레임마다 실행
    /// </summary>
    private void Update()
    {
        
    }

    /// <summary>
    /// 스크립트가 활성화 되는 도중 매 프레임마다 프레임을 그리고(화면을 그리고) 실행
    /// </summary>
    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// 유니티에서 설정된 값(초) 마다 한번씩 실행
    /// </summary>
    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// 맨 처음 활성화 되거나 비활성화 되고 난 후 활성화 됬을때
    /// -> 상태가 활성화로 변경되었을때
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable 발동");
    }

    /// <summary>
    /// OnEnable이랑 반대,
    /// 스크립트나 오브젝트가 비활성화 되거나 삭제되었을 때 발동    
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("OnDisable 발동");
    }

    /// <summary>
    /// 스크립트가 삭제(파괴)됬을 때 발동
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("OnDestroy 발동");
    }
}
