using Doozy.Runtime.UIManager.Components;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonUI : MonoBehaviour
{
    public TMP_Text skillName;
    public TMP_Text skillDescription;

    public UIButton button;
    public BaseSkill skillToAdd;
    
    public void Init()
    {
        skillName.text = "Upgrade " + skillToAdd.skillName;
        skillDescription.text = skillToAdd.skillDescription;
        button.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => SkillManager.instance.AddSkill(skillToAdd));
        button.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => SkillManager.instance.HideAvailableSkills());

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
