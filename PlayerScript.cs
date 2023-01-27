using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public Text countText;
	public Text winText;
	public Text loseText;
	public Text timerText;
	public float speed;
	private Rigidbody myBody;
	private float totalTime;
	private float timeLeft;
	private bool gameWon;
	public int collectiblesCount;
	public GameObject next;
	public GameObject reset;


	void Start()
	{
		winText.text = "";  //initialize the winText value
		loseText.text = ""; //initialize the loseText value
		totalTime = 20;
		timeLeft = totalTime;
		gameWon = false;
		timerText.text = "Timer: " + timeLeft.ToString();
		myBody = GetComponent<Rigidbody>();
		next.gameObject.SetActive(false);
		reset.gameObject.SetActive(false);
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");     //Access the right and left arrow keys
		float moveVertical = Input.GetAxis("Vertical");         //Access the up and down arrow keys
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3s deal with movement in 3D space.  X, Y, and Z aspects.  In this case the Y is zero.  Vector3s take floats.
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); //This accesses the rigidbody component and adds force ot get it moving
		myBody.AddForce(movement * speed * Time.deltaTime);

		//controlling the timer

		timerText.text = "Timer: " + timeLeft.ToString("F1");
		if (gameWon == false)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				//what happens if I lose? Goes here.
				ILose();

			}
		}

		if (gameWon == true)
        {
			if (collectiblesCount == 6)
			{
				winText.text = "GOT PELLETS!";
				Iwin();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			collectiblesCount ++;
			countText.text = "Score: " + collectiblesCount.ToString() + "/6";
		}

		if (collectiblesCount == 6)
		{
			gameWon = true;
			winText.text = "YOU WIN!";
			gameObject.SetActive(false);
			next.gameObject.SetActive(true);
		}
	}

	

	public void ILose ()
    {
		reset.gameObject.SetActive(true);
	}

	public void Iwin ()
    {
		next.gameObject.SetActive(true);
	}
		


}
