using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstCode : MonoBehaviour
{
    public float MoveSpeed = 10;
    public Transform Ball;
    public Transform PosDribble;
    public Transform PosOverHead;
    public Transform Arms;
    public Transform Target;

    private bool IsBallInHands = true;
    private bool IsBallFlying = false;
    private bool IsBallReturning = false;
    private float T = 0;

    // Update is called once per frame
    void Update()
    {
        // Walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * MoveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + direction);

        if (IsBallInHands)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Ball.position = PosOverHead.position;
                Arms.localEulerAngles = Vector3.right * 180;

                transform.LookAt(Target.parent.position);
            }
            else
            {
                Ball.position = PosDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                Arms.localEulerAngles = Vector3.right * 0;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ReleaseBall();
            }
        }

        if (IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = PosOverHead.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            Ball.position = pos + arc;

            if (t01 >= 1)
            {
                IsBallFlying = false;
                Ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            IsBallReturning = true;
            T = 0;
        }

        if (IsBallReturning)
        {
            ReturnBallToCharacter();
        }
    }

    private void ReleaseBall()
    {
        IsBallInHands = false;
        IsBallFlying = true;
        T = 0;
        Ball.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void ReturnBallToCharacter()
    {
        T += Time.deltaTime;
        float duration = 1.0f;
        float t01 = T / duration;

        Vector3 A = Ball.position;
        Vector3 B = PosDribble.position;
        Vector3 pos = Vector3.Lerp(A, B, t01);

        Ball.position = pos;

        if (t01 >= 1)
        {
            IsBallReturning = false;
            IsBallInHands = true;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Ball && !IsBallInHands)
        {
            IsBallInHands = true;
            IsBallFlying = false;
            IsBallReturning = false;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
