using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using UnityEditor.UIElements; 
using UnityEngine.UIElements; 

public class WizardUI : EditorWindow
{
  
    [MenuItem("WizardUI/Open _%#T")]
    public static void ShowWindow()
    {
        // Opens the window, otherwise focuses it if it’s already open.
        var window = GetWindow<WizardUI>();

        // Adds a title to the window.
        window.titleContent = new GUIContent("WizardUI");

        // Sets a minimum size to the window.
        window.minSize = new Vector2(250, 50);
    }
    

}
