using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyInteractions : MonoBehaviour
{
    [SerializeField] private PlayerControllerr playerController;
    [SerializeField] private int damageToDeal = 15;


    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            if (playerController != null)
            {
                playerController.TakeDamage(damageToDeal);

            }
            else
            {
                Debug.Log("playerController is null");
            }



        }

    }

}
