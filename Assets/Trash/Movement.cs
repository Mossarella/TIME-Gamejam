using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float intervalOfDoubleTap;

    public float fastMoveSpeed = 4f;

    public float slowMoveSpeed = 2f;

    bool waitingForDoubleTap_Left = false;

    bool waitingForDoubleTap_Right = false;

    bool normal_isMovingLeft = false;

    bool fast_isMovingLeft = false;

    bool normal_isMovingRight = false;

    bool fast_isMovingRight = false;

    private void Update()
    {
        Run();

    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (waitingForDoubleTap_Left)
            {
                normal_isMovingLeft = false;
                fast_isMovingLeft = true;
            }
            waitingForDoubleTap_Left = true;
            normal_isMovingLeft = true;
            StartCoroutine(WaitForDoubleTap_Left());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (waitingForDoubleTap_Right)
            {
                normal_isMovingRight = false;
                fast_isMovingRight = true;
            }
            waitingForDoubleTap_Right = true;
            normal_isMovingRight = true;
            StartCoroutine(WaitForDoubleTap_Right());
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            normal_isMovingLeft = false;
            fast_isMovingLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            normal_isMovingRight = false;
            fast_isMovingRight = false;
        }
    }

    private void FixedUpdate()
    {
        RunFixedUpdate();

    }

    private void RunFixedUpdate()
    {
        if (normal_isMovingLeft)
        {
            gameObject.transform.Translate(-1 * transform.right * Time.fixedDeltaTime * slowMoveSpeed);
        }

        if (fast_isMovingLeft)
        {
            gameObject.transform.Translate(-1 * transform.right * Time.fixedDeltaTime * fastMoveSpeed);
        }

        if (normal_isMovingRight)
        {
            gameObject.transform.Translate(transform.right * Time.fixedDeltaTime * slowMoveSpeed);
        }

        if (fast_isMovingRight)
        {
            gameObject.transform.Translate(transform.right * Time.fixedDeltaTime * fastMoveSpeed);
        }
    }

    private IEnumerator WaitForDoubleTap_Left()
    {
        yield return new WaitForSecondsRealtime(intervalOfDoubleTap);
        waitingForDoubleTap_Left = false;
    }
    private IEnumerator WaitForDoubleTap_Right()
    {
        yield return new WaitForSecondsRealtime(intervalOfDoubleTap);
        waitingForDoubleTap_Right = false;
    }

}