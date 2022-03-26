using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclusionAlarm : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private AudioSource _alarm;
    private bool _isReductionAlarm = true;
    private float _valueReductionAlarm = 0.01f;
    private Coroutine changeVolume;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Stop();
            StopCoroutine(changeVolume);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
             changeVolume = StartCoroutine(ChangeVolumeAlarm());
            
        }
    }

    private IEnumerator ChangeVolumeAlarm()
    {
        while (true)
        {
            if (_isReductionAlarm)
            {
                _alarm.volume -= _valueReductionAlarm;
                if (_alarm.volume == 0)
                {
                    _isReductionAlarm = false;
                }
            }
            else
            {
                _alarm.volume += _valueReductionAlarm;
                if (_alarm.volume == 1)
                {
                    _isReductionAlarm = true;
                }
            }
            yield return null;
        }
    }
}
