using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonstrationEffect : MonoBehaviour {
    public string  demonstrationText;
    public Font font;
    public Canvas canvas;

    [Range(6,40)]
    public int fontSize;
    [Range(0f, 100f)]
    public float radius;
    [Range(0f, 100f)]
    public float speed;

    [HideInInspector]
    public bool allowCircleMovement = false;

    
    private GameObject textObject;
    private Text text;
    private RectTransform rectTransform;
    private float angle = 0;

    // speeds over 0.04 are too high, so limit the range from 0 to 0.04 scaled to 0 to 100
    // same for radius, but from 0 to 10,000 scaled to 0 to 100
    private float speedMultiplier = 0.04f / 100;
    private float radiusMultiplier = 100;

    // Start is called before the first frame update
    void Start() {
        // Need GameObject to exist to add Text component
        textObject = new GameObject();
        textObject.transform.parent = canvas.transform;
        textObject.name = "Demonstration text";

        // Text component is added to the GameObject
        // and is modified according to initial values set above in editor
        text = textObject.AddComponent<Text>();
        text.font = font;
        text.text = demonstrationText;
        text.fontSize = fontSize;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;

        // Get the text box and set the size of it
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(400, 200);
        changeLocation(0, 0);
    }

    // Update is called once per frame
    void Update() {

        // Make text follow a circular path
        if (allowCircleMovement) {
            float newX = (Mathf.Cos(speedMultiplier * speed * angle) * Mathf.PI) / 180f;
            float newY = (Mathf.Sin(speedMultiplier * speed * angle) * Mathf.PI) / 180f;
            changeLocation(radiusMultiplier * radius * newX, radiusMultiplier * radius * newY);
            angle++;
        }

        // Let the font size change during runtime
        if (text.fontSize != fontSize) {
            text.fontSize = fontSize;
        }
    }


    void changeLocation(float x, float y) {
        rectTransform.localPosition = new Vector3(x, y, 0);
    }

    public void toggleMovement() {
        allowCircleMovement = !allowCircleMovement;
    }
}
