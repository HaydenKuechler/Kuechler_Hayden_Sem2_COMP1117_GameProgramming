
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy: Character 
{
  [Header("Enemy Settings")]
  [SerializeField] private float patrolDistance = 5.0f;

    private Vector2 startPos;
    private int direction = -1;
    protected override void Awake()
    {
        base.Awake();

        Debug.Log("Awake in enemy.cs");

        startPos = transform.position;
    }


    private void Update()
    {
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        if(transform.position.x >= rightBoundary)
        {
            direction = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }
                                                                         //Enemy moving side to side 
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
