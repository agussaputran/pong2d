using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameIsOver : MonoBehaviour 
{

[SerializeField]
Text winnerTxt;

	void Start () 
	{
		if(Data.scoreP1 == 5)
		{
			winnerTxt.text = "Player 1 Menang";
		}
		else
		{
			winnerTxt.text = "Player 2 Menang";
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(1);
	}
	public void MenuGame()
	{
		SceneManager.LoadScene(0);
	}
}
