using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
        [SerializeField] float ScreenWidthInUnits = 16f;
        [SerializeField] float minX = 1f;
        [SerializeField] float maxX = 15f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MousePositionHorizontal = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        //Debug.Log(MousePositionHorizontal);
        Vector3 PaddlePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PaddlePosition.x = Mathf.Clamp(MousePositionHorizontal, minX, maxX);
        transform.position = PaddlePosition;
    }
}
