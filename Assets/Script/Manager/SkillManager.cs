using Doozy.Runtime.UIManager.Animators;
using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public List<BaseSkill> availableSkills = new List<BaseSkill>();
    List<BaseSkill> currentActiveSkills = new List<BaseSkill>();
    PlayerCharacter player;

    public UIContainer container;

    public SkillButtonUI skillButtonPrefab;
    public Transform skillButtonSpawnTransform;

    [SerializeField]
    int level = 1;
    [SerializeField]
    int currentExp = 0;
    [SerializeField]
    int nextExpToLevelUp = 25;

    public void AddExp(int Exp)
    {
        currentExp += Exp;
        if(currentExp > nextExpToLevelUp)
        {
            nextExpToLevelUp = nextExpToLevelUp * level;
            ShowAvailableSkills();
            currentExp = 0;
            level++;
        }
    }

    private void Awake()
    {
        instance = this;
        player = GameObject.FindObjectOfType<PlayerCharacter>();
        //InitAvailableSkills();
        //ShowAvailableSkills();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitAvailableSkills()
    {
        foreach (var item in availableSkills)
        {
            var btn = Instantiate(skillButtonPrefab, skillButtonSpawnTransform);
            btn.skillToAdd = item;
            btn.Init();
        }
    }

    public void AddSkill(BaseSkill skill)
    {
        var find = availableSkills.Find(x => x.skillName == skill.skillName);
        if(find != null)
        {
            find.OnLevelUp();
        }

        else
        {
            var skillClone = Instantiate(skill, player.transform);
            availableSkills.Add(skillClone);
        }
    }

    public void ShowAvailableSkills()
    {
        container.Show();
        Time.timeScale = 0;
    }

    public void HideAvailableSkills()
    {
        container.Hide();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
