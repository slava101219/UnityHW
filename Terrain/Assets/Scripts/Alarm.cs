using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private bool _isReductionVolume = true;
    private float _valueChangeVoleum = 0.01f;
    private Coroutine _changeVolume;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Stop();
            StopCoroutine(_changeVolume);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
             _changeVolume = StartCoroutine(ChangeVolumeAlarm());
            
        }
    }

    private IEnumerator ChangeVolumeAlarm()
    {
        while (true)
        {
            if (_isReductionVolume)
            {
                _alarm.volume -= _valueChangeVoleum;
                if (_alarm.volume == 0)
                {
                    _isReductionVolume = false;
                }
            }                            
            else
            {
                _alarm.volume += _valueChangeVoleum;
                if (_alarm.volume == 1)
                    _isReductionVolume = true;
            }                              
            yield return null;
        }
    }
}
