using UnityEngine;

using TMPro;

public class DistanceMeasure : MonoBehaviour

{

    private static GameObject lastClickedObject = null;

    private static GameObject firstClickedObject = null;

    private static Color defaultColor = Color.white;

    private Renderer rend;

    public static LineRenderer line; // shared LineRenderer for drawing the line

    public TMP_Text distanceText;    // assign via inspector

    public TMP_Dropdown actionDropdown; // assign via inspector

    public TMP_Dropdown unitDropdown;   // assign via inspector

    private float currentDistance = 0f;

    private string currentUnit = "Meters";

   private static bool isObjectSelected = false;
   private static Texture2D crosshairCursor;
   private static Vector3? firstPoint = null;
private static Vector3? lastPoint = null;
    void Start()

    {

 // Create a simple crosshair texture at runtime
       crosshairCursor = MakeCrosshairTexture(32, 32, Color.red);
        rend = GetComponent<Renderer>();

        if (rend != null)

            rend.material.color = defaultColor;

        // Create a shared LineRenderer if it doesn't exist

        if (line == null)

        {

            GameObject lineObj = new GameObject("DistanceLine");

            line = lineObj.AddComponent<LineRenderer>();

            line.startWidth = 0.05f;

            line.endWidth = 0.05f;

            line.material = new Material(Shader.Find("Sprites/Default"));

            line.startColor = Color.red;

            line.endColor = Color.red;

        }

        // Setup action dropdown

        if (actionDropdown != null)

        {

            actionDropdown.options.Clear();

            actionDropdown.options.Add(new TMP_Dropdown.OptionData("Rotate"));

            actionDropdown.options.Add(new TMP_Dropdown.OptionData("Move Forward"));

            actionDropdown.options.Add(new TMP_Dropdown.OptionData("Move Backward"));

            actionDropdown.gameObject.SetActive(false);

            actionDropdown.onValueChanged.AddListener(OnActionDropdownChanged);

        }

        // Setup unit dropdown

        if (unitDropdown != null)

        {

            unitDropdown.options.Clear();

            unitDropdown.options.Add(new TMP_Dropdown.OptionData("Meters"));

            unitDropdown.options.Add(new TMP_Dropdown.OptionData("Centimeters"));

            unitDropdown.options.Add(new TMP_Dropdown.OptionData("Millimeters"));

            unitDropdown.gameObject.SetActive(false);

            unitDropdown.onValueChanged.AddListener(OnUnitDropdownChanged);

        }

    }

    void OnMouseDown()

    {

   // your existing OnMouseDown code...
       isObjectSelected = true;
       // Change cursor
       if (crosshairCursor != null)
           Cursor.SetCursor(crosshairCursor, new Vector2(16, 16), CursorMode.Auto);
        // Reset previous object's color

        if (lastClickedObject != null && lastClickedObject != gameObject)

        {

            Renderer prevRend = lastClickedObject.GetComponent<Renderer>();

            if (prevRend != null)

                prevRend.material.color = defaultColor;

        }

        // Update current object's color

        if (rend != null)

            rend.material.color = Color.yellow;

        // Update clicked objects

        if (firstClickedObject == null)

        {

            firstClickedObject = gameObject;

            lastClickedObject = null;

        }

        else if (lastClickedObject == null)

        {

            lastClickedObject = gameObject;

        }

        else

        {

            firstClickedObject = lastClickedObject;

            lastClickedObject = gameObject;

        }

        // Show dropdowns for the currently selected object

        if (actionDropdown != null)

        {

            actionDropdown.gameObject.SetActive(true);

            actionDropdown.value = 0;

        }

        if (unitDropdown != null)

        {

            unitDropdown.gameObject.SetActive(true);

            unitDropdown.value = 0;

        }

        // Draw line & show distance if we have both objects

        if (firstClickedObject != null && lastClickedObject != null)

        {

            UpdateLineAndDistance();

        }

    }


     public static void ResetSelection()
   {
       firstClickedObject = null;
       lastClickedObject = null;
       if (line != null)
           line.positionCount = 0;
       isObjectSelected = false;
       // Reset to default cursor
       Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
   }
   // Utility: generate a simple crosshair texture
   Texture2D MakeCrosshairTexture(int width, int height, Color color)
   {
       Texture2D tex = new Texture2D(width, height);
       Color[] pixels = new Color[width * height];
       // Fill transparent
       for (int i = 0; i < pixels.Length; i++)
           pixels[i] = Color.clear;
       int midX = width / 2;
       int midY = height / 2;
       // Vertical line
       for (int y = 0; y < height; y++)
           pixels[y * width + midX] = color;
       // Horizontal line
       for (int x = 0; x < width; x++)
           pixels[midY * width + x] = color;
       tex.SetPixels(pixels);
       tex.Apply();
       return tex;
   }

   void Update()
{
   // Left mouse click
   if (Input.GetMouseButtonDown(0))
   {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       if (Physics.Raycast(ray, out hit))
       {
           // Ensure it hit a cube
           if (hit.collider != null && hit.collider.gameObject == gameObject)
           {
               isObjectSelected = true;
               // Change cursor
               if (crosshairCursor != null)
                   Cursor.SetCursor(crosshairCursor, new Vector2(16, 16), CursorMode.Auto);
               // Save the hit point
               if (firstPoint == null)
               {
                   firstPoint = hit.point;
                   lastPoint = null;
               }
               else if (lastPoint == null)
               {
                   lastPoint = hit.point;
               }
               else
               {
                   firstPoint = lastPoint;
                   lastPoint = hit.point;
               }
               // Draw line if both points selected
               if (firstPoint != null && lastPoint != null)
               {
                   UpdateLineAndDistance();
               }
           }
       }
   }
   // Reset cursor when nothing selected
   if (!isObjectSelected)
       Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
   if (firstPoint != null && lastPoint != null)
       UpdateLineAndDistance();
}
void UpdateLineAndDistance()
{
   if (firstPoint == null || lastPoint == null) return;
   Vector3 startPos = (Vector3)firstPoint;
   Vector3 endPos = (Vector3)lastPoint;
   line.positionCount = 2;
   line.SetPosition(0, startPos);
   line.SetPosition(1, endPos);
   currentDistance = Vector3.Distance(startPos, endPos);
   if (distanceText != null)
       distanceText.text = "Distance: " + FormatDistance(currentDistance) + " " + currentUnit;
}

    // Format distance based on selected unit

    string FormatDistance(float distance)

    {

        switch (currentUnit)

        {

            case "Centimeters":

                return (distance * 100f).ToString("F2");

            case "Millimeters":

                return (distance * 1000f).ToString("F2");

            default: // Meters

                return distance.ToString("F2");

        }

    }

    // Handle object action dropdown

    void OnActionDropdownChanged(int index)

    {

        GameObject target = lastClickedObject != null ? lastClickedObject : firstClickedObject;

        if (target == null) return;

        switch (index)

        {

            case 0: // Rotate

                target.transform.Rotate(Vector3.up * 95f);

                break;

            case 1: // Move Forward

                target.transform.Translate(Vector3.forward * 1f);

                break;

            case 2: // Move Backward

                target.transform.Translate(Vector3.back * 1f);

                break;

        }

    }

    // Handle unit dropdown

    void OnUnitDropdownChanged(int index)

    {

        switch (index)

        {

            case 0:

                currentUnit = "Meters";

                break;

            case 1:

                currentUnit = "Centimeters";

                break;

            case 2:

                currentUnit = "Millimeters";

                break;

        }

        // Refresh displayed distance

        if (firstClickedObject != null && lastClickedObject != null && distanceText != null)

        {

            distanceText.text = "Distance: " + FormatDistance(currentDistance) + " " + currentUnit;

        }

    }

}
 