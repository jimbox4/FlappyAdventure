using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int _contactDamage;
    [Header("Shooter")]
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _shootDelay;
    [Header("Movment")]
    [SerializeField] private EnemyMover _mover;
    EnemyCollisionHandler _collisionHandler = new EnemyCollisionHandler();

    private void Awake()
    {
        _mover.Intialize(transform);
    }

    private void OnEnable()
    {
        StartCoroutine(_shooter.Shooting(_shootDelay, (int)Vector2.left.x));
    }

    private void Update()
    {
        if (IsDead)
        {
            DestroyThisObject();
        }

        _mover.Move();

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_collisionHandler.TryHandleCollision(collision, _contactDamage))
        {
            DestroyThisObject();
        }
    }
}
