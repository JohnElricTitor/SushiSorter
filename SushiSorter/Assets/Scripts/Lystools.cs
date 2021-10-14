using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lystools : MonoBehaviour
{
    public Stats stats;

    public InputField spawnValue;
    public InputField conveyorValue;
    public InputField deathValue;

    public void Assign ()
    {
        if (spawnValue.text != "")
            stats.SpawnRate = float.Parse(spawnValue.text);
        else
            stats.SpawnRate = 0;
        
        if (spawnValue.text != "")
            stats.ConveyorSpeed = float.Parse(conveyorValue.text) * -1;
        else
            stats.ConveyorSpeed = 0;
        
        if (spawnValue.text != "")
            stats.death = int.Parse(deathValue.text);
        else
            stats.death = 0;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
