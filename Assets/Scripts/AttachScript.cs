using UnityEngine;

//скрипт прикрепляет текущий обьект к переданному Transform
public class AttachScript : MonoBehaviour
{
    Transform target;

    float offsetX;
    float offsetY;

    public void attach(Transform target)
    {
        this.target = target;
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    public void clear()
    {
        target = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 currPos = transform.position;
        currPos.x = target.position.x + offsetX;
        currPos.y = target.position.y + offsetY;

        transform.position = currPos;

    }
}
