using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import to change scenes

public class MainMenu : MonoBehaviour
{
    public void PlayGame() // Public method to press play game button
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Grabbing next scene in queue
    }


}
