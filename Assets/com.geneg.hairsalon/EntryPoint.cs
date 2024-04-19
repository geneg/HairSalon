using System;
using com.geneg.hairsalon;
using com.geneg.hairsalon.Common;
using com.geneg.hairsalon.ToolFeature;
using com.geneg.hairsalon.ToolPanelFeature;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private FeatureResolver _featureResolver = new FeatureResolver();
    
    [SerializeField]
    private ViewMap _viewMap;
    
    private void Awake()
    {
        //create features (only initialize but not start)
        //feature is a kind of controller but more global and it can have child controllers for smaller tasks
        //feature is created at the beginning of the game and it is destroyed at the end of the game
        
        // it is two kinds of message broadcasters (EventBus and FeatureBus)
        // EventBus is for global message broadcasting
        // FeatureBus is for local message broadcasting within the feature
        
        //list of features
        // 1. ToolPanel
        // 2. CharacterFeature
        // 3. DragAndDropFeature
        // 4. ToolFeature - create and manage tools on the game scene
        _featureResolver.Inject(new EventBus());
        _featureResolver.AddFeature(FeatureType.ToolPanel, new ToolPanelFeature(this.transform), _viewMap.GetView(FeatureType.ToolPanel));
        _featureResolver.AddFeature(FeatureType.ToolFeature, new ToolFeature(this.transform), _viewMap.GetView(FeatureType.ToolFeature));
    }

    // Start is called before the first frame update
    void Start()
    {
        _featureResolver.GetFeature(FeatureType.ToolPanel).StartFeature();
        _featureResolver.GetFeature(FeatureType.ToolFeature).StartFeature();
    }
    
    private void OnApplicationQuit()
    {
        
    }
}
