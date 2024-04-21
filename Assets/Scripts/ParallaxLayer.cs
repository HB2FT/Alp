using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    public void Move(float delta)
    {
        Vector2 newPos = transform.position;
        newPos.x -= delta * parallaxFactor;

        transform.position = newPos;
    }

}
