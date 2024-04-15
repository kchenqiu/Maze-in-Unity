using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public MazeGenerator mazeGeneratorPrefab;    
    public GameObject playerPrefab;
    public int level;
    private MazeGenerator mazeGenerator;
    private GameObject player;

    private void Awake(){
        Instance = this;   
        player = Instantiate(playerPrefab) as GameObject; 
        BeginGame();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            RestartGame();
        }
    }

    private void BeginGame(){        
        mazeGenerator = Instantiate(mazeGeneratorPrefab) as MazeGenerator;
        mazeGenerator.setSize(10 + (level *10), 10 + (level *10));
        mazeGenerator.GenerateMaze(10 + (level *10), 10 + (level *10));      
    }

    private void RestartGame(){
        mazeGenerator.DeleteMaze();
        Destroy(mazeGenerator);
        BeginGame();
    }

    public void Levelup(){
        level++;
        RestartGame();
    }

    public int GetMazeSize(){
        return level*10;
    }
}