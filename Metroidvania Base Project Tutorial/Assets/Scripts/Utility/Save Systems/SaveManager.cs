using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public byte[] playerHealth;
}

public class SaveManager : MonoBehaviour {
    private string saveFileName = "savedata.json";
    private byte[] key = new byte[] { 0x11, 0x12, 0x03, 0x01 };

    public void SaveGame(int health) {
        SaveData data = new SaveData();
        data.playerHealth = Encoding.UTF8.GetBytes(health.ToString());

        for (int i = 0; i < data.playerHealth.Length; i++) {
            data.playerHealth[i] = (byte)(data.playerHealth[i] ^ key[i % key.Length]);
        }

        string jsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        File.WriteAllText(filePath, jsonData);
    }

    public int LoadGame() {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(filePath)) {
            string jsonData = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            // XOR decryption
            for (int i = 0; i < data.playerHealth.Length; i++) {
                data.playerHealth[i] = (byte)(data.playerHealth[i] ^ key[i % key.Length]);
            }

            string healthString = Encoding.UTF8.GetString(data.playerHealth);
            int health = 0;
            int.TryParse(healthString, out health);

            return health;
        } 
        else {
            return 0;
        }
    }
}