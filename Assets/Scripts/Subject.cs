using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEngine.Events;

public enum Phobia
{
	Arachnophobia,
	Claustrophobia,
	Coulrophobia,
}

public class Subject : MonoBehaviour
{
	[Serializable]
	struct PhobiaEvent
	{
		public Phobia Phobia;
		public UnityEvent Event;
	}

	[SerializeField]
	private List<PhobiaEvent> phobias = default;

	public enum State
	{
		Walk,
		Run,
		Freeze,
	}

	[SerializeField]
	private float speed = 1;
	[SerializeField]
	private float runSpeed = 2;

	[SerializeField] private float jumpForce = 1;

	[SerializeField]
	private int direction = 1;
	[SerializeField]
	private State state = State.Walk;

	private Rigidbody2D rb = null;

    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
		switch (state)
		{
			case State.Walk:
				rb.velocity =  new Vector2(speed * direction, rb.velocity.y);
				break;
			case State.Run:
				rb.velocity = new Vector2(runSpeed * direction, rb.velocity.y);
				break;
			case State.Freeze:
				rb.velocity = new Vector2(0, rb.velocity.y);
				break;
		}
    }

	public void Turn()
	{
		direction = -direction;
		Vector3 newLocalScale = transform.localScale;
		newLocalScale.x = Mathf.Abs(newLocalScale.x) * direction;
		transform.localScale = newLocalScale;
	}

	public void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	}

	public void Run()
	{
		state = State.Run;
	}

	public void Freeze()
	{
		state = State.Freeze;
	}

	public void Walk()
	{
		state = State.Walk;
	}

	public void TriggerPhobia(Phobia in_phobia)
	{
		foreach (var phobia in phobias)
		{
			if(phobia.Phobia == in_phobia)
				phobia.Event?.Invoke();
		}
	}
}
