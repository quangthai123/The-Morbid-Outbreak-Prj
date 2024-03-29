using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody rb { get; private set; }

    public Transform orientation;

    [Header("Move Infor")]
    public float moveSpeed;

    [Header("collide check")]
    [SerializeField] private float collideCheckRadius;
    [SerializeField] private Transform collideCheckPos;
    [SerializeField] private LayerMask playerLayer;
    protected virtual void Awake()
    {
        anim = transform.Find("Model").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void Start()
    {
        this.orientation = transform.Find("Orientation").transform;
        this.collideCheckPos = transform.Find("Collide Check Pos").transform;
        
    }
    public bool CheckCollideObj() => Physics.CheckSphere(collideCheckPos.position, collideCheckRadius, playerLayer);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(collideCheckPos.position, collideCheckRadius);
    }
}
