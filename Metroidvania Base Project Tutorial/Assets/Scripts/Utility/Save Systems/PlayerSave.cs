using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private int playerHealth = 0;
    private SaveManager saveManager;
    private Player player;

    void Start() {
        saveManager = FindObjectOfType<SaveManager>();
        player = GetComponent<Player>();
        playerHealth = saveManager.LoadGame();
    }

    void Update() {
        playerHealth = player.GetHealth();

        if (Input.GetKeyDown(KeyCode.O)) {
            saveManager.SaveGame(playerHealth);
            print("Health saved!");
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            playerHealth = saveManager.LoadGame();
            player.SetHealth(playerHealth);
        }
    }
}