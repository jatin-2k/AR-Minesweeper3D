using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	// public variables
	public PlaySpaceGenerator playSpace;

	public GameObject UiCanvas;
	public GameObject gameOver;
	public GameObject gameWon;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;
	public bool isGameStarted = false;

	public string playAgainLevelToLoad;
	public string nextLevelToLoad;


	// setup the game
	void Start () {

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (UiCanvas)
			UiCanvas.SetActive (false);

		// inactivate the playAgainButtons gameObject, if it is set
		if (gameOver)
			gameOver.SetActive (false);

		// inactivate the nextLevelButtons gameObject, if it is set
		if (gameWon)
			gameWon.SetActive (false);
	}

	// this is the main game event loop
	void Update () {
		//generate new minefield
		if (Input.GetKeyDown(KeyCode.G))
		{
			playSpace.GeneratePlaySpace();
			isGameStarted = true;
		}
		//toggle ShowMines
		if (Input.GetKeyDown(KeyCode.S))
		{
			playSpace.ToggleShowMines();
		}

		if (!gameIsOver && isGameStarted) {
			if (playSpace.minefield.isGameWon) {  // check to see if beat game
				BeatLevel ();
			} 
			else if (playSpace.minefield.isGameLost) { // check to see if timer has run out
				EndGame ();
			}
            else
            {
				//game is in playing state here
				if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began)) // for touch Input
				{
					Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					RaycastHit raycastHit;
					if (Physics.Raycast(raycast, out raycastHit))
					{
						if (raycastHit.collider.CompareTag("Field"))
						{
							playSpace.minefield.FieldClicked(raycastHit.collider.gameObject.GetComponent<FieldBlock>().PositionInGraph);
						}
					}
				}
				else if (Input.GetMouseButton(0)) // for mouse input
				{
					Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit raycastHit;
					if (Physics.Raycast(raycast, out raycastHit))
					{
						if (raycastHit.collider.CompareTag("Field"))
						{
							playSpace.minefield.FieldClicked(raycastHit.collider.gameObject.GetComponent<FieldBlock>().PositionInGraph);
						}
					}
				}
			}
		}
	}

	public void EndGame() {
		// game is over
		gameIsOver = true;

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (UiCanvas)
			UiCanvas.SetActive (true);
	
		// activate the playAgainButtons gameObject, if it is set 
		if (gameOver)
			gameOver.SetActive (true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		gameIsOver = true;

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (UiCanvas)
			UiCanvas.SetActive (true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (gameWon)
			gameWon.SetActive (true);
		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}


	// public function that can be called to restart the game
	public void RestartGame ()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
        SceneManager.LoadScene(playAgainLevelToLoad);
	}

	// public function that can be called to go to the next level of the game
	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
        SceneManager.LoadScene(nextLevelToLoad);
	}
	

}
