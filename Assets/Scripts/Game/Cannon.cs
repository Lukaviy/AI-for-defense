using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject CannonObject;
    public GameObject CannonBallPrefab;

    public float RotateSpeed;

    public ICannonAI CannonAi;

    public int MaxAmmo;
    private int _ammo;

    public event CannonBall.CannonBallHitHandler Hit;
    public event EventHandler NoAmmo;

	void Start ()
	{
	    Reload();
	}

    IEnumerator PrepareShoot(float shootAngle)
    {
        var currentAngle = Vector3.Angle(CannonObject.transform.rotation * Vector3.forward, Vector3.forward);
        var rotateStep = (shootAngle - currentAngle) * RotateSpeed;

        for (float angle = currentAngle; Mathf.Abs(angle - shootAngle) > 0.1f; angle += rotateStep)
        {
            CannonObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.left);
            yield return null;
        }

        CannonObject.transform.rotation = Quaternion.AngleAxis(shootAngle, Vector3.left);

        yield return new WaitForSeconds(1);

        var cannonBall = Instantiate(CannonBallPrefab, CannonObject.transform.position, CannonObject.transform.rotation);
        var cannonBallComponent = cannonBall.GetComponent<CannonBall>();

        cannonBallComponent.Hit += CannonBallComponent_Hit;
        cannonBallComponent.Hit += Hit;
    }

    private void CannonBallComponent_Hit(bool hitTarget, float distance)
    {
        if (!hitTarget)
        {
            CannonAi.FeedbackHitDistance(distance);
            Shoot();
        }
    }

    public void StartShooting(float distance)
    {
        CannonAi.SetTarget(distance);
        Shoot();
    }

    public void Reload()
    {
        _ammo = MaxAmmo;
    }

    private void Shoot()
    {
        if (_ammo <= 0)
        {
            if (NoAmmo != null) NoAmmo.Invoke(this, EventArgs.Empty);
            return;
        }

        _ammo--;
        
        var shootAngle = CannonAi.GetShootAngle();
        StartCoroutine(PrepareShoot((float)shootAngle));
    }
}
