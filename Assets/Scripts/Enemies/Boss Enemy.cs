using UnityEngine;

public class BossEnemy : Enemy 

 
{
    void Start()
    {
        // 1. Double the size of the sprite
        transform.localScale *= 2f;

        // 2. Set a “golden” tint
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Gold color 
            spriteRenderer.color = new Color(1f, 0.84f, 0f);

        }

        // 3. Double the speed (This variable now comes from Enemy.cs)
        moveSpeed *= 2f;
    }
    void Update()
    {
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;
        // Continuous movement: Call every frame
        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);
        
        if (transform.position.x >= rightBoundary)
        {
            direction = -1;
            transform.localScale = new Vector3(2, 2, 2);
        }
        //Enemy moving side to side 
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;
            transform.localScale = new Vector3(-2, 2, 2);
        }
    }

}
