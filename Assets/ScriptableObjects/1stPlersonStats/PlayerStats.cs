using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    //permanent values
    public float health;
    public float movementSpeed;
    public float jumpHeight;
    public float gravity;
}
