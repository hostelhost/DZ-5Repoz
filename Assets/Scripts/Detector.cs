using UnityEngine;
[RequireComponent(typeof(Alarm))]
[RequireComponent(typeof(Player))]

public class Detector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _alarm.EnhancementSound();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _alarm.ReductionSound();
    }
}
