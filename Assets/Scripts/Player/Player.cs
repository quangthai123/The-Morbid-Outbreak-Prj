using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerRunState runState { get; private set; }

    #endregion
    [Header("First Person View Info")]
    [SerializeField] private float senX;
    [SerializeField] private float senY;

    private float rotateX;
    private float rotateY;
    private Transform cameraTransformRef;
    private Transform cameraPos;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        runState = new PlayerRunState(this, stateMachine, "Run");
    }
    protected override void Start()
    {
        base.Start();
        Physics.gravity *= 10f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        this.cameraTransformRef = FindObjectOfType<Camera>().transform;      
        this.cameraPos = transform.Find("CameraPos").transform;       
        stateMachine.Initialize(idleState);
    }
    void Update()
    {
        stateMachine.currentState.Update();
        float mouseX, mouseY;
        GetMouseAxis(out mouseX, out mouseY);
        HandleFirstPersonView(mouseX, mouseY);   
    }
    
    private void GetMouseAxis(out float mouseX, out float mouseY)
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;
    }
    private void HandleFirstPersonView(float mouseX, float mouseY)
    {
        this.rotateX -= mouseY;
        this.rotateY += mouseX;

        this.rotateX = Mathf.Clamp(rotateX, -75f, 90f);

        this.cameraTransformRef.rotation = Quaternion.Euler(this.rotateX, this.rotateY, 0f);
        this.orientation.rotation = Quaternion.Euler(0f, rotateY, 0f);
        transform.rotation = Quaternion.Euler(0f, rotateY, 0f);
        this.cameraTransformRef.position = cameraPos.position;
    }
}
