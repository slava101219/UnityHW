using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclusionAlarm : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private AudioSource _alarm;
    private bool _isReductionAlarm = true;
    private float _valueReductionAlarm = 0.01f;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeVolumeAlarm();
    }

    private void ChangeVolumeAlarm()
    {
        if(_isReductionAlarm)
        {
            _alarm.volume -= _valueReductionAlarm;
            if(_alarm.volume == 0)
            {
                _isReductionAlarm = false;
            }
        }
        else
        {
            _alarm.volume += _valueReductionAlarm;
            if(_alarm.volume == 1)
            {
                _isReductionAlarm = true;
            }
        }
    }
}
