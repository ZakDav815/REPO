using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIDocument _uiDoc;

    public enum LabelState
    {
        Empty, 
        x, 
        o
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //check if _uiDoc exists
        if (!_uiDoc)
        {
            Debug.Log("Not found UIDocument!");
            return;
        }
        
        //create an alias for the root visual element
        VisualElement root = _uiDoc.rootVisualElement;

        LabelState init = _uiDoc.rootVisualElement;

        map = new LabelState[,]
        {
            {init, init, init},
            {init, init, init},
            {init, init, init}
        };

        for(int row =0; row < GameBoard.GetLength(0); row++)
        {
            for(int col=0; col < GameBoard.GetLenth(1); col++)
            {
                string label_txt = map[row,col] == LabelState.Empty ? "-" : map[row,col].ToString();
                GameBoard[row,col].text = label_txt;
                GameBoard[row,col].pickingMode = PickingMode.Position;
                GameBoard[row,col].RegisterCallback<ClickEvent>(OnLabelClicked);
            }
        }

        //create alias references to the instances
        Label a1 = root.Q<Label>("a1");//Q is short for query
        Label a2 = root.Q<Label>("a2");//so we querry for the specific child instance of the root
        Label a3 = root.Q<Label>("a3");//the root in this case is the VisualElement
        Label b1 = root.Q<Label>("b1");
        Label b2 = root.Q<Label>("b2");
        Label b3 = root.Q<Label>("b3");
        Label c1 = root.Q<Label>("c1");
        Label c2 = root.Q<Label>("c2");
        Label c3 = root.Q<Label>("c3");

        GameBoard = new Label[,]
        {
            {a1, a2, a3},
            {b1, b2,b3},
            {c1, c2, c3}
        };

        //change label text
        //enabled the interactivity on label
        //add event listener
        for (int i=0; i < labels_obj.Length; i++)
        {
            labels_obj[i].text = labels_str[i];
            labels_obj[i].pickingMode = PickingMode.Position;

            labels_obj[i].RegisterCallback<ClickEvent>(OnLabelClicked);
        }

        //a1.text = "A1";

    }

    // Declare the OnLabelClicked method(the Callback Function).

    void OnLabelClicked(ClickEvent evt) {
        //created a alias for the instance
        VisualElement target = evt.target as VisualElement;
        //Output the instance name to the console
        Debug.Log("Label Clicked " + target.name);
        int[] GameBoardIndex = new int[2];
        for(int col=0; col < GameBoard.GetLength(1); row++)
        {
            for(int col=0; col < GameBoard.GetLength(1); col++)
            {
                if(GameBoard[row,col] == target)
                {
                    GameBoardIndex[0] = row;
                    GameBoardIndex[1] = col;
                }
            }
        }
        Debug.Log(GameBoardIndex[0] + ":" + GameBoardIndex[1]);
    }
}
