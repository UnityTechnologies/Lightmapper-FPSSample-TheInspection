using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
	public float speedMultiplier = 3f;

	private Vector3 _inputVector;
	private float _currentSpeed;
	private Animator _animator;
	private Transform _transform;
	private Rigidbody _rigidbody;
	private Vector3 verticalOffset = new Vector3(0f, 0f, 0f);

	void Awake()
    {
        _animator = GetComponent<Animator>();
		_transform = GetComponent<Transform>();
		_rigidbody = GetComponent<Rigidbody>();
    }

	private void Update()
	{
		float _hor = Input.GetAxis("Horizontal");
		float _ver = Input.GetAxis("Vertical");
		_inputVector = (new Vector3(_hor, 0f, _ver));

	}

	private void FixedUpdate()
	{
		if(_inputVector.sqrMagnitude > 1f)
		{
			_inputVector.Normalize();
		}

		if(_inputVector.sqrMagnitude != 0f)
		{
			Step(_inputVector);
		}
		else
		{
			_animator.SetBool("IsMoving", false);
		}
	}

    private void Step(Vector3 movementVector)
	{
		float input = movementVector.magnitude;
		Vector3 newPosition = _transform.position + movementVector * Time.deltaTime * speedMultiplier;
				
		NavMeshHit hit;
		NavMesh.SamplePosition(newPosition, out hit, .3f, NavMesh.AllAreas);
		bool hasMoved = (_transform.position - hit.position).magnitude >= .02f;
		
		if(hasMoved)
		{
			_transform.position = hit.position + verticalOffset;
			_animator.SetBool("IsMoving", hasMoved);
			_transform.forward = Vector3.Slerp(_transform.forward, movementVector, Time.deltaTime * 7f);
		}
		else
		{
			//stops the animation when the character reaches the border of the NavMesh (even if input is still on)
			_animator.SetBool("IsMoving", false);
		}

		_animator.SetFloat("CurrentSpeed", input);
		
	}
}
