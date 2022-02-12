
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameHasEnded = false;
    [SerializeField] private float respawnTime;

    private void Awake()
    {
        if (GameManager.instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

             return instance;
        }
    }

    public void GameOver()
    {
        gameHasEnded = true;
        UIManager _ui =  GetComponent<UIManager>();
        if(_ui != null && gameHasEnded)
        {
            _ui.ToggleDeathPanel();
        }
    }
    public void EndGame()
    {
        
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
           Invoke("Restart",respawnTime);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Test");
    }
}
