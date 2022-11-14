using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool onScreen = true;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Camera cam;
    public Vector2 mousePos;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void OnMouseExit()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
        float mousePosY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);
        Vector2 newMousePos = new Vector2(mousePosX, mousePosY);
        mousePos = cam.ScreenToWorldPoint(newMousePos);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onScreen)
            {
                onScreen = false;
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }

            else
            {
                onScreen = true;
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
                
        }
    }
}
