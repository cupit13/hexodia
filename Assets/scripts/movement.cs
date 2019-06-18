using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public bool pcCtrl;

    private Vector3 moveDirection = Vector3.zero;
    public GameObject lookAtTarget;
    public GameObject rotatedObj;
    public Vector2 roundedPos;
    public bool isFalling;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    //void dirUpdate(float tx,float ty)
    //{
    //    float sum = Mathf.Pow(tx,2) + Mathf.Pow(ty, 2);
    //    float sqrt = Mathf.Sqrt(sum);
    //    float ry = Mathf.Rad2Deg * Mathf.Acos(tx/sqrt);
    //    transform.eulerAngles = new Vector3 (0, ry, 0);
    //}

    Vector2 roundedPosOp(float tx, float tz)
    {
        int txR = Mathf.CeilToInt(tx + 4.5f);
        int tyR = Mathf.CeilToInt(tz + 4.5f);
        Vector2 res = new Vector2(txR, tyR);
        return res;
    }

    void Update()
    {
        roundedPos = roundedPosOp(transform.position.x, transform.position.z);

        if (characterController.isGrounded)
        {
            if (Mathf.Abs(moveDirection.x) > 0 || Mathf.Abs(moveDirection.y) > 0 || Mathf.Abs(moveDirection.z) > 0)
            {
                lookAtTarget.transform.localPosition = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
                rotatedObj.transform.LookAt(lookAtTarget.transform);
            }

            if (!isFalling)
            {
                // We are grounded, so recalculate
                // move direction directly from axes
                if (pcCtrl)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                    moveDirection *= speed;

                    if (Input.GetButton("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                }
                else
                {
                    moveDirection = new Vector3(-Input.GetAxis("switchH"), 0.0f, Input.GetAxis("switchV"));
                    moveDirection *= speed;

                    if (Input.GetButton("switchB"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                }
            }


        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}