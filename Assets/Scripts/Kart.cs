using Unity.Hierarchy;
using UnityEngine;
using System.IO.Ports;
using System;

[RequireComponent (typeof(Rigidbody))]
public class Kart : MonoBehaviour
{

	private Rigidbody rb;

	public int xInput = 0;
	public bool isAccelerating = false;

	private const float k_MoveSpeed = 10.0f;
	private const float k_SteerFactor = 50.0f;

	private SerialPort myPort;

	[SerializeField] string portname = "COM3";

	byte buttons = 0;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.isKinematic = false;
		rb.freezeRotation = true;

		myPort = new SerialPort(portname, 9600);

		myPort.Open();
	}

	void OnDestroy()
	{
		myPort.Close();
	}

	public void OnSteerInput()
	{

	}

	public void OnAccelerateInput()
	{

	}

	private void Update()
	{
		while (myPort.BytesToRead > 0)
		{
			buttons = (byte)myPort.ReadByte();
			buttons = (byte)~buttons;
		}

		Debug.Log(Convert.ToString(buttons, 2).PadLeft(8, '0'));

		isAccelerating = (buttons & 1) != 0;

		bool right = (buttons & 2) != 0;
		bool left = (buttons & 4) != 0;

		xInput = 0;

		if (left) {
			--xInput;
		}

		if (right) {
			++xInput;
		}
	}

	private void FixedUpdate()
	{
		if (isAccelerating)
		{
			Quaternion rawRot = transform.rotation;
			Vector3 rot = rawRot.eulerAngles;
			Vector3 rotationVector = new Vector3(0, rot.y + (xInput * k_SteerFactor * Time.fixedDeltaTime), 0);
			rb.MoveRotation(Quaternion.Euler(rotationVector));

			Vector3 moveDir = transform.forward;
			rb.MovePosition(transform.position + (moveDir * k_MoveSpeed * Time.fixedDeltaTime));
		}
	}
}
