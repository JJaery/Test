using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject missilePrefab;
    public float AttackSpeed = 1.5f;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    public override void Hitted(Bullet bullet)
    {
        HP -= bullet.damage;

        if (HP < 0)
        {
            GameManager.Instance.score += 100 * StageManager.Instance.CurrentStage;
            StageManager.Instance.EnemyDown(this);
            Destroy(gameObject);
        }
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(AttackSpeed);
        }
    }

    void Attack()
    {
        GameObject target = Instantiate(missilePrefab);
        Bullet script = target.GetComponent<Bullet>();
        //script.owner = gameObject;
        script.ownerTag = gameObject.tag;
        target.transform.position = transform.position;
        target.transform.Rotate(new Vector3(0, 0, 180));
    }
}
