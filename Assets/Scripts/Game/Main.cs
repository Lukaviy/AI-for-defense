using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    public Cannon Cannon;
    public GameObject TargetPrefab;
    public int MinTargetDistance;
    public int MaxTargetDistance;

    private float _currentDistance;

    private GameObject TargetInstance;

	void Start () {
		Cannon.CannonAi = new Solution();

	    Cannon.Hit += CannonOnHit;
        Cannon.NoAmmo += CannonOnNoAmmo;

        NewTest();
    }

    private void CannonOnNoAmmo(object sender, EventArgs eventArgs)
    {
        Debug.Log("Не осталось боеприпасов!");
    }

    private void NewTest()
    { 
        _currentDistance = GetNewTargetPosition();
        Cannon.Reload();
        Cannon.StartShooting(_currentDistance);
        TargetInstance = Instantiate(TargetPrefab, new Vector3(0, 0, _currentDistance), new Quaternion());
    }

    private void CannonOnHit(bool hitTarget, float distance)
    {
        if (hitTarget)
        {
            Debug.Log("Попадание!");
            Destroy(TargetInstance);
            NewTest();
        }
        else
        {
            Debug.Log(distance < _currentDistance ? "Недолет!" : "Перелет!");
        }
    }

    int GetNewTargetPosition()
    {
        return Random.Range(MinTargetDistance, MaxTargetDistance);
    }
}
