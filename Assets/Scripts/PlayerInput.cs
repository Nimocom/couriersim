using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    Camera mainCamera;

    string xAxis = "Horizontal";
    string yAxis = "Vertical";

    int usingPhoneParamID;
    int speedParamID;
    int moveParamID;

    Player player;
    Customer customer;
    Transform headTarget;

    [SerializeField] Transform head;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        moveParamID = Animator.StringToHash("IsMoving");
        speedParamID = Animator.StringToHash("Speed");
        usingPhoneParamID = Animator.StringToHash("UsingPhone");

        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis(xAxis);
        float y = Input.GetAxis(yAxis);

        if (Input.GetKey(KeyCode.LeftShift) && player.GetStamina() > 0.1f)
            y *= 2f;


        animator.SetBool(moveParamID, y > 0.3f ? true : false);

        animator.SetFloat(speedParamID, y, 0.5f, Time.deltaTime);

        float cameraY = mainCamera.transform.eulerAngles.y;
        if (characterController.velocity.magnitude > 0.1f && !Phone.Instance.IsActive)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, cameraY, 0f), 12f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Phone.Instance.ShowPhone();
            animator.SetBool(usingPhoneParamID, Phone.Instance.IsActive);
            Cursor.visible = Phone.Instance.IsActive;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (customer)
                customer.CheckOrder(player.bin);
        }

        if (customer)
        {
            customer.headTarget.position = head.position;
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 animatorDeltaPosition = animator.deltaPosition;
        animatorDeltaPosition.y = 30f * Physics.gravity.y;

        characterController.Move(animatorDeltaPosition);
    }

    public void OnCustomerMet(Customer customer)
    {
        this.customer = customer;
        UIManager.Instance.SetInteractionHint(true);
        customer.HeadRig.weight = 1f;
    }

    public void OnCustomerLost(Customer customer)
    {
        this.customer = null;
        UIManager.Instance.SetInteractionHint(false);

        customer.HeadRig.weight = 0f;
    }
}
