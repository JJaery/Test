using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    ///// 방법 1. 현재 시간을 저장하고, 매 프레임마다 시간이 몇초 경과했는지 체크
    //float currentTime = 0.0f;

    //void Start()
    //{
    //    //currentTime을 스크립트 시작 시간으로 설정
    //    currentTime = Time.time;
    //}
    //void Update()
    //{
    //    if(Time.time - currentTime > 5f) // 스크립트가 활성화 되고나서 5초 지났을 때 발동
    //    {
    //        Something();
    //        currentTime = Time.time; // currentTime을 발동 시점으로 변경
    //    }
    //}

    ///방법2 : 유니티의 코루틴을 사용한다. (Coroutine)

    Coroutine various;

    private void Start()
    {
        various = StartCoroutine(testCoroutine());

    }

    IEnumerator testCoroutine()
    {
        Debug.Log("바로실행!");

        yield return null; // 한 프레임 대기
        Debug.Log("한 프레임 뒤에 실행!");

        yield return new WaitForFixedUpdate(); // FixedTime 만큼 대기
        Debug.Log("FixedTime 뒤에 실행!");

        yield return new WaitForSeconds(2f); // 1초 대기 (게임 속도 영향 있음)
        Debug.Log("2초 뒤에 실행!!");

        yield return new WaitForSecondsRealtime(4f); // 게임속도와 영향없는 실제 시간
        Debug.Log("실제 시간으로 4초 뒤에 실행!! (앞에 2초 때문에 실질적으론 6초 이상 걸림)");

    }

    void Something()
    {
        Debug.Log("발동됨");
    }
}
