using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public Transform LeftWall;
    public Transform RightWall;
    public float ExtraMargin;
    void Update()
    {
        float moveinput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + Vector3.right * moveinput;
        newPosition.x = Mathf.Clamp(newPosition.x, LeftWall.transform.position.x+ ExtraMargin, RightWall.transform.position.x - ExtraMargin);
        transform.position = newPosition;
    }
}
