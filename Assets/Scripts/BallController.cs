using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
	public int force;
	public AudioClip hitSound;
	public GameObject particleFX;

	Rigidbody2D rb;

	[SerializeField]
	private Text scoreUIP1, scoreUIP2;

	AudioSource suara;
	void Start ()
	{
		suara = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		Vector2 arah = new Vector2(2, 0).normalized;
		rb.AddForce(arah * force);
		
		Data.scoreP1 = 0;
		Data.scoreP2 = 0;
	}
	
	void Update ()
	{
		
	}

	void TampilkanScore()
	{
		Debug.Log("Score P1: "+Data.scoreP1+", Score P2: "+Data.scoreP2);
		scoreUIP1.text = Data.scoreP1 + "";
		scoreUIP2.text = Data.scoreP2 + "";
	}

	void ResetBall()
	{
		transform.localPosition = new Vector2(0, 0);
		rb.velocity = new Vector2(0, 0);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		suara.PlayOneShot(hitSound);

		Instantiate(particleFX, transform.position, transform.rotation);
		
		if(other.gameObject.name == "RightSide")
		{
			Data.scoreP1 += 1;
			TampilkanScore();

			if(Data.scoreP1 == 5)
			{
				Destroy(gameObject);
				SceneManager.LoadScene(3);
				return;
			}

			ResetBall();
			Vector2 arah = new Vector2(2, 0).normalized;
			rb.AddForce(arah * force);
		}

		if(other.gameObject.name == "LeftSide")
		{
			Data.scoreP2 += 1;
			TampilkanScore();

			if(Data.scoreP2 == 5)
			{
				Destroy(gameObject);
				SceneManager.LoadScene(3);
				return;
			}

			ResetBall();
			Vector2 arah = new Vector2(2, 0).normalized;
			rb.AddForce(arah * force);
		}

		if(other.gameObject.name == "Player1" || other.gameObject.name =="Player2")
		{
			float sudut = (transform.position.y - other.transform.position.y) * 5f;
			Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
			rb.velocity = new Vector2(0, 0);
			rb.AddForce(arah * force * 2);
		}
	}
}
