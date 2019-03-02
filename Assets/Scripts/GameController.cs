using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardcount=0;
	public float spawnWait, startWait, waveWait;
	public Text scoreboard, Gameovertext, HighscoreDis;
	public Button restartbutton;
	private bool gameover;
	private bool restart;
	private int score;
	private int oldHighScore;


	public Button start;
	public Canvas running_game, gameoverobj;
	private bool game_running=false;
	// Use this for initialization
	void Awake(){
		oldHighScore = PlayerPrefs.GetInt ("highscore", 0);
		HighscoreDis.text = "High Score:" + oldHighScore;
	}
	void Start(){
		//main_menu.enabled = true;
		running_game.enabled = false;
		gameoverobj.enabled=false;

		Start_My_Game();

	}
	void Start_My_Game() {
		score = 0;
		game_running = true;
		running_game.enabled = true;
		gameover = false;
		restart = true;
		Gameovertext.text = "";
		//main_menu.enabled = false;
		restartbutton.enabled=true;
		restartbutton.CancelInvoke();
		//gameoverobj.SetActive (false);
		//restartbutton.
		//Gameovertext.;
		GameController gamecontroller = GetComponent<GameController> ();
		gamecontroller.updateScore (0);
		//StartCoroutine (SpawnWaves());
		restartbutton.onClick.AddListener (()=>restartM());
	}
	public void restartM(){
		if (score > oldHighScore) {
			PlayerPrefs.SetInt ("highscore", score);
		}
		Application.LoadLevel (Application.loadedLevel);
	}
	IEnumerator SpawnWaves(){
		//yield return new WaitForSeconds(startWait);
		//while(true){

			for(int count=0;count<hazardcount;count++){
				Vector3 spawnPosition=new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard,spawnPosition,spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			

			yield return new WaitForSeconds(waveWait);
			/*if(gameover){
				restartbutton.enabled=true;
				restart=true;
				gameoverobj.SetActive(true);
				break;
			}*/
		
	}
	// Update is called once per frame
	void Update () {
		if(game_running)
		{
			GameObject[] hazards = GameObject.FindGameObjectsWithTag ("Asteroid");
			Debug.Log (hazards.Length.ToString ());
			if (hazards.Length <= 1) {
				hazardcount++;
				StartCoroutine (SpawnWaves ());
			}
		}
	}
	public void updateScore(int points){
		score = score + points;
		scoreboard.text = "Score: "+score;
		if (score > oldHighScore) {
			HighscoreDis.text="High Score:"+score;
		}
	}
}
