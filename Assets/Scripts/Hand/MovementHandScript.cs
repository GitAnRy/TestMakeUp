using UnityEngine;

//скрипт отвечает за перемещение руки по экрану в режиме Drag
public class MovementHandScript : MonoBehaviour
{
    [SerializeField] HandScript hand;
    private Vector2 lastMousePos;

    private float scrWidth, scrHeiht;
    
    void Start()
    {
        float screenHeightInUnits = Camera.main.orthographicSize * 2;
        float screenWidthInUnits = screenHeightInUnits * Screen.width / Screen.height;

        scrWidth = Screen.width/ screenWidthInUnits;
        scrHeiht = Screen.height/ screenHeightInUnits;
    }


    public void OnMouseUp()
    {
        if (hand.isDrag)
        {
            hand.stopDrag();
            lastMousePos = Vector2.zero;
        }
    }

    public void OnMouseDrag()
    {
        if (!hand.isDrag)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;
            Vector2 deltaPos = Vector2.zero;

            if (lastMousePos == Vector2.zero)
                lastMousePos = currentMousePos;

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector2 currPos = hand.transform.position;
            currPos.x = currPos.x + deltaPos.x / scrWidth;
            currPos.y = currPos.y + deltaPos.y / scrHeiht;

            hand.transform.position = currPos;
        }
    }
}
