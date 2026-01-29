using UnityEngine;

public class PlayerStats
{
    //Private fields
    private float moveSpeed;
    public float jumpheight;
    private int maxHealth;
    private int currentHealth;

    //Public Properties

    


    //Side Quest A
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            if (value > 20)
            {
                moveSpeed = 20;
            }
            else
            {
                moveSpeed = value;
            }
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }
        public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, 100);
            currentHealth = value;
            Debug.Log("Health Set to max");
        }
    }

    
        //Constructor 

        public PlayerStats()
    {
        moveSpeed = 10;
        maxHealth = 100;
        currentHealth = 100;
        
    }

    public PlayerStats(float moveSpeed,int maxHealth)
    {
        this.moveSpeed = moveSpeed;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;

        Debug.Log("Player initalized with Max speed and Max health");
    }

    
    
    
    

    
    

 
    
   
    
}

