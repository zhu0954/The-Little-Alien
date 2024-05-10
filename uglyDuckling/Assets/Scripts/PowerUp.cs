
using UnityEngine;

public class PowerUp : MonoBehaviour{
    public float increase = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            PlatformerMoveAnimated playerScript = player.GetComponent<PlatformerMoveAnimated>();
            if (playerScript)
            {
                playerScript.jumpSpeed += increase;
                Destroy(gameObject);
            }
        }
    }
}
