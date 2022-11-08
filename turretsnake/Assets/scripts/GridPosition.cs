using UnityEngine;

public class GridPosition : MonoBehaviour
{
    public float x, y;
    public float xLast, yLast;

    [SerializeField] Vector3 position;
    [SerializeField] float animationSpeed, smoothing;
    private void Awake()
    {
        x = (int)transform.position.x;
        y = (int)transform.position.z;
        AssignLast();
    }

    private void AssignLast()
    {
        xLast = x;
        yLast = y;
    }

    public void AssignXandY(float x, float y)
    {
        AssignLast();
        this.x = x;
        this.y = y;
    }
    
    public Vector3 GetFullPosition()
    {
        return position;
    }

    private void FixedUpdate()
    {
        if (x != Mathf.RoundToInt(transform.position.x) || y != Mathf.RoundToInt(transform.position.z))
        {
            position = new Vector3(x, (int)transform.position.y, y);
        }

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(x, y)) > 0.05f) //Check if we are near endpoint, if not, move
        {
            float trueSmooth = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(x, y));
            //Debug.Log(trueSmooth);

            transform.position = Vector3.Lerp(transform.position, position, (animationSpeed*trueSmooth)/trueSmooth*smoothing);
        }
           
    }

}
