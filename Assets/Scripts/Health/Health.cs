using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(10);
        }
        if (healthAmount == 0)
        {
            gameController.Die();
            Heal(100);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        StartCoroutine(UpdateHealthBarAfterDelay(0.5f)); // Start a coroutine with a delay
    }

    IEnumerator UpdateHealthBarAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        healthBar.fillAmount = healthAmount / 100f; // Update the health bar fill
    }
}
