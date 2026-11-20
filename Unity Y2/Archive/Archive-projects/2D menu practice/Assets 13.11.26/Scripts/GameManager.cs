using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIDocument _uiDoc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!_uiDoc)
        {
            Debug.Log("Not found UIDocument!");
            return;
        }

        VisualElement root = _uiDoc.rootVisualElement;

        string[] labels_str = new string[] { "a1", "a2", "a3", "b1", "b2", "b3", "c1", "c2", "c3" };

        Label a1 = root.Q<Label>("a1");//Q is short for query
        Label a2 = root.Q<Label>("a2");//so we querry for the specific child instance of the root
        Label a3 = root.Q<Label>("a3");//the root in this case is the VisualElement
        Label b1 = root.Q<Label>("b1");
        Label b2 = root.Q<Label>("b2");
        Label b3 = root.Q<Label>("b3");
        Label c1 = root.Q<Label>("c1");
        Label c2 = root.Q<Label>("c2");
        Label c3 = root.Q<Label>("c3");

        Label[] labels_obj = new Label[] { a1, a2, a3, b1, b2, b3, c1, c2, c3 };

        for (int i=0; i < labels_obj.Length; i++)
        {
            labels_obj[i].text = labels_str[i];
            labels_obj[i].pickingMode = PickingMode.Position;

            labels_obj[i].RegisterCallback<ClickEvent>(OnLabelClicked);
        }

        //a1.text = "A1";

    }

    // Declare the OnLabelClicked method

    void OnLabelClicked(ClickEvent evt) {
        VisualElement target = evt.target as VisualElement;
        Debug.Log("Label Clicked " + target);
    }
}
