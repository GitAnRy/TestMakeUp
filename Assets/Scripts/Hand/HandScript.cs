using System;
using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public bool isAnimated { get; private set; } = false;
    public bool isDrag { get; private set; } = false;
    private Action onCancelDrag;

    private Vector2 defaultPosition;

    [SerializeField] AnimationCurve curveAnimationX;

    void Start()
    {
        defaultPosition = transform.position;
    }

    //переместить руку в нужную позици
    public void moveTo(Vector2 position)
    {
        if (isAnimated)
            return;

        isAnimated = true;
        StartCoroutine(Animate(position, null));
    }

    //переместить руку в нужную позици
    public void moveTo(Vector2 position, Action action)
    {
        if (isAnimated)
            return;

        isAnimated = true;
        StartCoroutine(Animate(position, action));
    }

    //переместить руку в нужную позици
    //ожидать касания с перемещением руки
    //обратный вызов события при завершении касания
    public void moveToDrag(Vector2 position, Action action)
    {
        onCancelDrag = action;
        StartCoroutine(Animate(position, startDrag));
    }

    //возвращаем руку на исходную
    public void toDefault()
    {
        StartCoroutine(Animate(defaultPosition, null));
    }

    private void startDrag()
    {
        isAnimated = true;
        isDrag = true;
    }

    public void stopDrag()
    {
        isAnimated = false;
        isDrag = false;

        if (onCancelDrag != null)
            onCancelDrag();
    }

    //запускаем анимацию руки по X
    public void startAnimationX(Action action)
    {
        StartCoroutine(AnimateX(action));
    }

    private IEnumerator Animate(Vector2 to, Action action)
    {
        yield return null;

        float elapsed = 0f;
        float duration = 0.15f;

        Vector3 from = transform.position;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
        isAnimated = false;
        if (action != null)
            action();
    }

    private IEnumerator AnimateX(Action action)
    {
        yield return null;

        float elapsed = 0f;
        float duration = 0.5f;

        Vector3 def = transform.position;
        Vector3 start = transform.position;
        Vector3 end = transform.position;

        start.x -= 0.2f;
        end.x += 0.2f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, curveAnimationX.Evaluate(elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = def;
        isAnimated = false;
        if (action != null)
            action();
    }

}
