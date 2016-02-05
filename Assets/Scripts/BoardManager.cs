using UnityEngine;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random;
using System.Collections;
using System.Text;
using System.IO;

public class BoardManager : MonoBehaviour {

	// Variables
	public static BoardManager Boardo;
	
	// Define Map Size (old method)
	public int columns = 10; 
	public int rows = 10;
	// Define Map Size (new method)
	
    public int mapWidth = 12;
    public int mapHeight = 24;
	public List <List<Tile>> map = new List<List<Tile>>();
	
	// Turn Tracking -- 
	public int currentPlayerIndex = 0;
	public List <PlayerController> players = new List<PlayerController>();
	
	// Terrain Prefabs
	public GameObject Sea1;
	public GameObject Land1;
	public GameObject Landc2;
	public GameObject City1;
	
	// Map Loading
	public string fileNameToLoad = "Map1.txt";
	private int[,] tiles;
	
	public GameObject Player1;
	public GameObject CPU1;
	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> (); // Store tile positions

	// Initialise Abstract Tile Positions
	void Awake () {
			Boardo = this;
			tiles = Load (Application.dataPath + "\\" + fileNameToLoad);
			BuildMap ();
	}
	
	void InitialiseList () {
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add (new Vector3(x, y, 0f));
			}
		}
	}

	// Convert Abstract to real positions, place tiles
	void BoardSetup () {
		boardHolder = new GameObject ("Board").transform;
		for (int x = 0; x < columns; x++) {
			// create a row to add to 2D list
			List <Tile> row = new List<Tile>();
		
			for (int y = 0; y < rows; y++) {
				float PlotX = (float)x;
				float PlotY = (float)y ;

				Tile instance = ((GameObject)Instantiate (Sea1, new Vector3 (PlotX * 2, (PlotY + ((PlotX % 2) / 2)) * 2 , 0f), Quaternion.identity)).GetComponent<Tile>();
				// Give it a goodass grid position, and add to row
				row.Add (instance);
				instance.gridPosition = new Vector2(x, y);
				//Debug.Log (x);
				//Debug.Log (y);
				instance.transform.SetParent (boardHolder);
			}
			// Add row to map
			map.Add(row);
		}
		
	}
	
	// Switches Players turns, resetting the count if necessary 
	public void nextTurn() {
		if (currentPlayerIndex + 1 < players.Count) {
			currentPlayerIndex++;
		} else {
			currentPlayerIndex = 0;
		}
		Debug.Log("Turn ended");
		players[currentPlayerIndex].actionPoints = players[currentPlayerIndex].maxActionPoints;
	}
		
	// Moves player based on the destination tile
	public void moveCurrentPlayer(Tile destTile) {
		players[currentPlayerIndex].moveDestination = destTile.transform.position;
		//Debug.Log(players[currentPlayerIndex]);
	}
	
	// Runs attack logic against attacked player
	// which is presumably being attacked by the current player
	public void attackThisPlayer(PlayerController theVictim) {
		PlayerController theAttacker = players[currentPlayerIndex];
		for (int i = 0; i < theAttacker.numCannons; i++) {
			int shotFire = Random.Range(1, 6);
			if (shotFire < theAttacker.shootingAbility) {
				theVictim.health--;
				Debug.Log("Hit!");
			}
		}
	}
	

	void SpawnPlayer () {
		UserPlayer player;
		player = ((GameObject)Instantiate(Player1, new Vector3(2,1,0), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		player.gridPosition = new Vector2(1,0);
		//player = Player1.GetComponent<UserPlayer>();
		players.Add(player);
		player = ((GameObject)Instantiate(Player1, new Vector3(4,2,0), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		player.gridPosition = new Vector2(2,1);
		//player = Player1.GetComponent<UserPlayer>();
		players.Add(player);
		
		AIPlayer CPUplayer = ((GameObject)Instantiate(CPU1, new Vector3(2,5,0), Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
		//player = Player1.GetComponent<UserPlayer>();
		CPUplayer.gridPosition = new Vector2(1,2);
		players.Add(CPUplayer);

	}

	// Use this for initialization
	void Start () {
		InitialiseList ();
		//BoardSetup ();
		
		SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		players[currentPlayerIndex].TurnUpdate();
	}

    void BuildMap () {
        Debug.Log("Building Map...");
		boardHolder = new GameObject ("Board").transform;
        for(int i = 0; i < tiles.GetLength(0); i++) {
		// create a row to add to 2D list
			List <Tile> row = new List<Tile>();
            for(int j = 0; j < tiles.GetLength(1); j++) {
					float PlotX = (float)i;
					float PlotY = (float)j ;
                if(tiles[i,j] == 1) {
                    Tile instance = ((GameObject)Instantiate (Sea1, new Vector3 (PlotX * 2, (PlotY + ((PlotX % 2) / 2)) * 2 , 0f), Quaternion.identity)).GetComponent<Tile>();
					instance.gridPosition = new Vector2(i, j);
                    instance.transform.SetParent (boardHolder);
					row.Add (instance);
                } else
                if(tiles[i,j] == 2) {
                    Tile instance = ((GameObject)Instantiate (Land1, new Vector3 (PlotX * 2, (PlotY + ((PlotX % 2) / 2)) * 2 , 0f), Quaternion.identity)).GetComponent<Tile>();
                    instance.gridPosition = new Vector2(i, j);
					instance.transform.SetParent (boardHolder);
					row.Add (instance);
                } else
                if(tiles[i,j] == 3) {
                    Tile instance = ((GameObject)Instantiate (Landc2, new Vector3 (PlotX * 2, (PlotY + ((PlotX % 2) / 2)) * 2 , 0f), Quaternion.identity)).GetComponent<Tile>();
                    instance.gridPosition = new Vector2(i, j);
					instance.transform.SetParent (boardHolder);
					City city = ((GameObject)Instantiate (City1, new Vector3 (PlotX * 2, (PlotY + ((PlotX % 2) / 2)) * 2 , 0f), Quaternion.identity)).GetComponent<City>();
                    city.gridPosition = new Vector2(i, j);
					city.transform.SetParent (boardHolder);
					row.Add (instance);
                } 
				
            }
			Debug.Log("Row " + i + " of size " + row.Count + " finished");
				map.Add(row);
        }
        Debug.Log("Building Completed!");
    }

		// custom modulus function	
	public int modu (int x, int m) {
		return (x%m + m)%m;
	}
		// custom file loader function
	private int[,] Load(string filePath) {
        try {
            Debug.Log("Loading File...");
            using(StreamReader sr = new StreamReader(filePath) ) {
                string input = sr.ReadToEnd();
                string[] lines = input.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                int[,] tiles = new int[lines.Length, mapWidth];
                Debug.Log("Parsing...");
                for(int i = 0; i < lines.Length; i++) {
                    string st = lines[i];
                    string[] nums = st.Split(new[] {',' });
                    if(nums.Length != mapWidth) {
                   
                    }
                    for(int j = 0; j < Mathf.Min(nums.Length, mapWidth); j++) {
                        int val;
                        if(int.TryParse(nums[j], out val )) {
                            tiles[i,j] = val;
                        } else {
                            tiles[i,j] = 1;
                        }
                    }
                }
                Debug.Log("Parsing Completed!");
                return tiles;
            }
        }
        catch(IOException e) {
            Debug.Log(e.Message);
        }
        return null;
    }
}
