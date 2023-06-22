using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _speed = 3.0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        { 
            _player.transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _player.transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = true;
        }
    }
}
