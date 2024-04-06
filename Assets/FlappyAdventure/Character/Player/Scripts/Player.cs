using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private AudioSourceCreater _jumpSound;

    private PlayerInput _input;

    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        _mover.Initialize(transform);

        _input = new PlayerInput();

        _input.Player.Tap.performed += tapAction => MakeTapAction();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        if (IsDead)
        {
            DestroyThisObject();
        }
    }

    private void FixedUpdate()
    {
        _mover.RotateToFallValue();
    }

    private void MakeTapAction()
    {
        _shooter.Shoot((int)Vector2.right.x);
        _mover.Jump();
        _jumpSound.Create();
    }
}
