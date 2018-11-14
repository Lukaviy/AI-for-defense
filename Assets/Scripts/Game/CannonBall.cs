using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour { 
    public float InitVelocity;

    private Rigidbody _rigidbody;

    public delegate void CannonBallHitHandler(bool hitTarget, float distance);

    public event CannonBallHitHandler Hit;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.rotation * Vector3.forward * InitVelocity);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (Hit != null) Hit.Invoke(collision.gameObject.CompareTag("target"), transform.position.z);
        Hit = null;
        Destroy(gameObject);
    }
}
