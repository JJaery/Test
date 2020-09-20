using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject owner;
    public string ownerTag;

    public float bulletSpeed = 0.5f;
    public float lifeTime = 3f;
    public float damage = 15f;

    private void Awake()
    {
        StartCoroutine(CheckLife());
    }

    IEnumerator CheckLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ///Vector3.right와 transform.right 의 차이점은 절대벡터냐 상대벡터냐 차이점입니다.
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    #region 레거시
    ///// <summary>
    ///// isTrigger가 꺼져있는 상태, 물리연산이 시작됬을 때(Enter)
    ///// </summary>
    ///// <param name="collision"></param>
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject == owner)
    //        return;

    //    Character targetScript =
    //        collision.gameObject.GetComponent<Character>();

    //    if (targetScript != null)
    //    {
    //        targetScript.Hitted(this);
    //        Destroy(gameObject);
    //    }
    //}
    #endregion
    
    /// <summary>
    /// isTrigger가 True로 되었을 때, Trigger가 발동 되기 시작할 때
    /// Trigger란 특정 사건을 일으키는 주체
    /// 이번 상황에서의 사건이란, 충돌 감지를 말한다.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == owner.tag)
        if (collision.gameObject.tag == ownerTag)
            return;

        Character targetScript =
            collision.gameObject.GetComponent<Character>();

        if (targetScript != null)
        {
            targetScript.Hitted(this);
            Destroy(gameObject);
        }
    }
}