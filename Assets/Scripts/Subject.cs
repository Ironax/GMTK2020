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
	Ophidiophobia,
	Achluophobia,
	Phonophobia,
	Acrophobia,

}

public enum Reaction
{
	Jump,
	Freeze,
	Run,
	Turn,
}

public class Subject : MonoBehaviour
{
	[Serializable]
	struct PhobiaReaction
	{
		public Phobia Phobia;
		public Reaction Reaction;
	}

	[SerializeField] private EmotionRenderer emotionRenderer;

	[SerializeField]
	private List<PhobiaReaction> phobias = default;

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

	[SerializeField] private float runTime = 2;
	[SerializeField] private float freezeTime = 1;
	[SerializeField] private float jumpForce = 1;

	[SerializeField]
	private int direction = 1;
	[SerializeField]
	private State state = State.Walk;
	[SerializeField] private bool isGrounded = false;

	[SerializeField] AudioClip jumpSfx;
	[SerializeField] AudioClip runSfx;
	[SerializeField] AudioClip walkSfx;
	[SerializeField] AudioClip freezeSfx;
	[SerializeField] AudioClip turnSfx;
	AudioSource subjectAudio;

	private Rigidbody2D rb = null;
	private float currentReactionTimer = 0f;

    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		subjectAudio = gameObject.GetComponent<AudioSource>();
	}

    void FixedUpdate()
	{
		currentReactionTimer += Time.deltaTime;

		switch (state)
		{
			case State.Walk:
				rb.velocity =  new Vector2(speed * direction, rb.velocity.y);
				if (!subjectAudio.isPlaying && isGrounded)
				{
					subjectAudio.clip = walkSfx;
					subjectAudio.loop = true;
					subjectAudio.Play();
				}

				break;
			case State.Run:
				rb.velocity = new Vector2(runSpeed * direction, rb.velocity.y);

				if (currentReactionTimer >= runTime)
					state = State.Walk;
				break;
			case State.Freeze:
				rb.velocity = new Vector2(0, rb.velocity.y);

				if (currentReactionTimer >= freezeTime)
					state = State.Walk;
				break;
		}
    }

	private void OnCollisionEnter2D(Collision2D other)
	{
		isGrounded = true;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		isGrounded = false;
	}

	public bool React(Reaction reaction)
	{
		switch (reaction)
		{
			case Reaction.Turn:
				return Turn();
			case Reaction.Jump:
				return Jump();
			case Reaction.Freeze:
				return Freeze();
			case Reaction.Run:
				return Run();
			default:
				return Walk();
				
		}
	}

	public bool Turn()
	{
		direction = -direction;
		Vector3 newLocalScale = transform.localScale;
		newLocalScale.x = Mathf.Abs(newLocalScale.x) * direction;
		transform.localScale = newLocalScale;

		return true;
	}

	public bool Jump()
	{
		if (isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			subjectAudio.clip = jumpSfx;
			subjectAudio.loop = false;
			subjectAudio.Play();

			isGrounded = false;

			return true;
		}
		return false;
	}

	public bool Run()
	{
		state = State.Run;
		subjectAudio.clip = runSfx;
		subjectAudio.loop = true;
		subjectAudio.Play();
		currentReactionTimer = 0f;
		return true;
	}

	public bool Freeze()
	{
		state = State.Freeze;
		subjectAudio.clip = freezeSfx;
		subjectAudio.loop = false;
		subjectAudio.Play();
		currentReactionTimer = 0f;
		return true;
	}

	public bool Walk()
	{
		state = State.Walk;
		subjectAudio.clip = walkSfx;
		subjectAudio.loop = true;
		subjectAudio.Play();
		return true;
	}

	public bool TriggerPhobia(Phobia in_phobia)
	{
		foreach (var phobia in phobias)
		{
			if (phobia.Phobia == in_phobia)
			{
				if (!React(phobia.Reaction))
					return false;
				else
				{
					emotionRenderer.DrawEmotion(phobia.Reaction);
				}
			}
		}
		return true;
	}
}
