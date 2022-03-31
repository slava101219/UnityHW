using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageCars : MonoBehaviour
{ 
    private Spawner _spawner;

    private int _secondsOfWaiting = 2;

    private void Start()
    {
        var spawnCar = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_secondsOfWaiting);

        while (true)
        {
            _spawner.Spawn();
            yield return waitTime;
        }      
    }

    
}
