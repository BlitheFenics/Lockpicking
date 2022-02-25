using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public Camera camera;
    public Transform lockCylinder, pickPosition;
    public GameObject movingBar;
    private MovingBar movingBarScript;

    public float maxAngle = 90, lockSpeed = 10;

    [Min(1)] [Range(1, 25)]
    public float lockRange = 10;

    private float eulerAngle, unlockAngle;

    private Vector2 unlockRange;

    // Start is called before the first frame update
    void Start()
    {
        newLock();

        movingBarScript = movingBar.GetComponent<MovingBar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pickPosition.position;

        if(movingBarScript.movePick)
        {
            Vector3 dir = Input.mousePosition - camera.WorldToScreenPoint(transform.position);

            eulerAngle = Vector3.Angle(dir, Vector3.up);

            Vector3 cross = Vector3.Cross(Vector3.up, dir);
            if(cross.z < 0)
            {
                eulerAngle = -eulerAngle;
            }

            eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

            Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
            transform.rotation = rotateTo;
        }

        float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));

        float lockRotation = ((percentage / 100) * maxAngle) * movingBarScript.keyPressTime;
        float maxRotation = (percentage / 100) * maxAngle;
        float lockLerp = Mathf.Lerp(lockCylinder.eulerAngles.x, lockRotation, Time.deltaTime * lockSpeed);
        lockCylinder.eulerAngles = new Vector3(lockLerp, 90, 0);

        if(lockLerp >= maxRotation -1)
        {
            if(eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
            {
                Debug.Log("Unlocked");
                newLock();

                movingBarScript.movePick = true;
                movingBarScript.keyPressTime = 0;
            }
            else
            {
                float randomRotation = Random.insideUnitCircle.x;
                transform.eulerAngles += new Vector3(Random.Range(-randomRotation, randomRotation), 0, 0);
            }
        }
    }

    void newLock()
    {
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    }
}