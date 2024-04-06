using UnityEngine;
using UnityEngine.Device;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSourceCreater))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private LayerMask _layerMask;
    private AudioSourceCreater _audioCreator;
    private float _speed;
    private float _lifeTime;
    private int _damage;

    public void Initialize(float speed, int damage, LayerMask layerMask,float lifeTime = 5)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioCreator = GetComponent<AudioSourceCreater>();

        _layerMask = layerMask;
        _speed = speed;
        _damage = damage;
        _lifeTime = lifeTime;
        Destroy(gameObject, _lifeTime);
        _audioCreator.Create();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1<<collision.gameObject.layer == _layerMask && collision.transform.TryGetComponent(out Character character))
        {
            character.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
