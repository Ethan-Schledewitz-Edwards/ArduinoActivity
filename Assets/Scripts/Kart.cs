using Unity.Hierarchy;
using UnityEngine;
using System.IO.Ports;

[RequireComponent (typeof(Rigidbody))]
public class Kart : MonoBehaviour
{

	private Rigidbody rb;

	public int xInput = 0;
	public bool isAccelerating = false;

	private const float k_MoveSpeed = 10.0f;
	private const float k_SteerFactor = 10.0f;

	private SerialPort myPort;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.isKinematic = false;
		rb.freezeRotation = true;
	}

	public void OnSteerInput()
	{

	}

	public void OnAccelerateInput()
	{

	}

	private void Update()
	{
		
	}

	private void FixedUpdate()
	{
		if (isAccelerating)
		{
			Quaternion rawRot = transform.rotation;
			Vector3 rot = rawRot.eulerAngles;
			Vector3 rotationVector = new Vector3(0, rot.y + (xInput * k_SteerFactor * Time.deltaTime), 0);
			rb.MoveRotation(Quaternion.Euler(rotationVector));

			Vector3 moveDir = transform.forward;
			rb.MovePosition(transform.position + (moveDir * k_MoveSpeed * Time.deltaTime));
		}
	}
}
