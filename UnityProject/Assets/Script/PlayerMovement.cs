using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
            //dir = dir + Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }

        //대각선으로 이동할 경우 dir의 길이가 다른 경우의 수보다 길기 때문에
        //normalized로 길이를 맞춰준다.
        dir = dir.normalized;

        ///dir은 Vector2라 Vector3로 계산하라고 알려줘야 에러가 안난다.
        /// Time.deltaTime 은 프레임 간 시간인데 얘를 안 곱해주면 FPS의 숫자에 따라
        /// 연산량이 많아져서 이동속도가 빨라진다.
        Vector3 precPosition = transform.position + (Vector3)(dir * moveSpeed * Time.deltaTime);

        //Validation 체크
        if(precPosition.x > 8.5f)
        {
            precPosition = new Vector3(8.5f, precPosition.y, precPosition.z);
        }
        else if(precPosition.x < -8f)
        {
            precPosition = new Vector3(-8f, precPosition.y, precPosition.z);
        }

        if (precPosition.y > 4.33f)
        {
            precPosition = new Vector3(precPosition.x, 4.33f, precPosition.z);
        }
        else if (precPosition.y < -4.33f)
        {
            precPosition = new Vector3(precPosition.x, -4.33f, precPosition.z);
        }

        transform.position = precPosition;
    }

}
