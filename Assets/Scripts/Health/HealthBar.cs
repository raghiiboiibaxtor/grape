using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

   
    // Start is called before the first frame update
    void Start()
    {
        // Initialising the total health & grape bars upon starting the game
        totalHealthBar.fillAmount = playerHealth.currentHealth;
        

    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth;
        
    }
}
