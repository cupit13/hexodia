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
    public Vector2 lastPos;
    public bool isFalling;
    public bool isOnEdge;
    public bool isEffect;
    public bool isDashing;
    public bool dashReady;
    public bool powerFire;
    public bool powerWind;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        isDashing = false;
    }

    Vector2 roundedPosOp(float tx, float tz)
    {
        float mod = 1;
        int txR;
        int tyR;
        if (((tx +4.5f)%mod) < .5f)
        {
           txR  = Mathf.FloorToInt(tx + 4.5f);
        }
        else
        {
           txR = Mathf.CeilToInt(tx + 4.5f);
        }

        if (((tz + 4.5f) % mod) < .5f)
        {
            tyR = Mathf.FloorToInt(tz + 4.5f);
        }
        else
        {
            tyR = Mathf.CeilToInt(tz + 4.5f);
        }
         
        Vector2 res = new Vector2(txR, tyR);
        return res;
    }

    void lastPostCalc()
    {
        Vector2 curPos = roundedPosOp(transform.position.x, transform.position.z);

        if (roundedPos != curPos)
        {
            if (!isOnEdge)
            { 
            lastPos = roundedPos;
            }
            roundedPos = curPos;
        }
    }
    void Update()
    {
        if (transform.position.y > .6f)
        {
            transform.position = new Vector3(transform.position.x, .58f, transform.position.z);
        }

        if (!(isEffect || isDashing))
        { 
            if (Mathf.Abs(moveDirection.x) > 0 || Mathf.Abs(moveDirection.y) > 0 || Mathf.Abs(moveDirection.z) > 0)
            {
                lookAtTarget.transform.localPosition = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
                rotatedObj.transform.LookAt(lookAtTarget.transform);
            }
        }

        if (!(isFalling || isEffect || isDashing))
        {
            lastPostCalc();
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
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        if (gameObject.GetComponent<CharacterController>().enabled == true)
        {
            characterController.Move(new Vector3(moveDirection.x,0,moveDirection.z) * Time.deltaTime);
        }
    }
}