using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public string characterName = "Hero";
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Prevent health from going below zero
        Debug.Log($"{characterName} took {damage} damage. Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Prevent health from exceeding maxHealth
        Debug.Log($"{characterName} healed {amount}. Health: {currentHealth}");
    }

    void Die()
    {
        Debug.Log($"{characterName} has been defeated!");
        // Add death logic here, like playing an animation or disabling the character
    }
}
