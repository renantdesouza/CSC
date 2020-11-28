using System.Collections.Generic;
using System.Linq;
using BusinessException;
using Hero;
using Hero.Skill;
using SkillsViewer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillsViewerManager : MonoBehaviour
{
    private SkillsViewerService Service;
    private SkillService SkillService;
    private HeroService HeroService;
    private string[] Heroes;
    private int CurrentHeroIndex;
    private int LastCurrentHeroIndex;
    private int SelectedSkillIndex;
    private bool IsVisible;
    private static List<SkillView> _skillsView;
    private static List<SkillKnowledge> _skillsKnowledge;
    private static List<Skill> _skills;

    private GameObject SelectKnowledge;
    private Text SkillTitle;
    private Text SkillDescription;

    private GameObject AddSkillError;
    private Text ErrorMessage;

    private List<SkillView> ArrangedSkillKnowledges;
    
    private void Awake()
    {
        Service = SkillsViewerService.GetInstance();
        Heroes = Service.Heroes;

        if (Heroes == null || Heroes.Length == 0)
        {
            throw new HeroesInvalidArgumentException();
        }
        
        SkillService = SkillService.GetInstance();
        HeroService = HeroService.GetInstance();

        CurrentHeroIndex = 0;
        LastCurrentHeroIndex = -1;
        SelectedSkillIndex = -1;

        SelectKnowledge = GameObject.FindGameObjectWithTag("SelectKnowledge");
        SelectKnowledge.transform.localScale = new Vector3(0, 0, 0 );

        SkillTitle = GameObject.FindGameObjectWithTag("Skill_tittle").GetComponent<Text>();
        SkillDescription = GameObject.FindGameObjectWithTag("Skill_description").GetComponent<Text>();

        AddSkillError = GameObject.FindGameObjectWithTag("AddSkillError");
        AddSkillError.transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (CurrentHeroIndex == LastCurrentHeroIndex)
        {
            return;
        }

        LastCurrentHeroIndex = CurrentHeroIndex;
        
        var hero = Heroes[CurrentHeroIndex];
        _skillsView = Service.GetAllSkillsFrom(hero);
        _skillsKnowledge = SkillService.GetSkillsFrom(hero);
        _skills = SkillService.Skills;
        
        ArrangedSkillKnowledges = Arrange(hero);
        Draw(ArrangedSkillKnowledges);
    }

    // TODO CRIAR RECURSÃO PARA MONTAR A ARVORE DE SKILLS
    private static List<SkillView> Arrange(string heroName)
    {
        var parent = (_skills ?? throw new CannotLoadSkillsException(heroName))
            .First(s =>
            {
                var isParent = s.requirements == null;
                var containsInViewList = (_skillsView ?? throw new CannotLoadSkillsException(heroName))
                    .Any(sv => sv.name.Equals(s.name));
                return isParent && containsInViewList;
            });

        var children = FindAllChildrenFrom(parent);

        var grandChildren = new List<Skill>();
        children.ForEach(c => grandChildren
            .AddRange(FindAllChildrenFrom(c) ?? throw new CannotLoadSkillsException(heroName)));

        var skillsView = new List<SkillView>
        {
            (_skillsView ?? throw new CannotLoadSkillsException(heroName))
            .First(sv => sv.name.Equals(parent.name)),
        };
        
        skillsView.AddRange(FindAllChildrenFrom(children) ?? throw new CannotLoadSkillsException(heroName));
        skillsView.AddRange(FindAllChildrenFrom(grandChildren) ?? throw new CannotLoadSkillsException(heroName));
        
        return skillsView;
    }

    private static List<SkillView> FindAllChildrenFrom(IReadOnlyCollection<Skill> children)
    {
        return _skillsView
            .FindAll(sv => (children ?? throw new CannotLoadSkillsException())
                .Any(c => c.name.Equals(sv.name)));
    }

    private static List<Skill> FindAllChildrenFrom(Skill c)
    {
        return _skills.FindAll(s =>
        {
            if (s.requirements == null)
            {
                return false;
            }
            var isGrandChildren = s.requirements
                .Any(r => r.Contains(c.name ?? throw new SkillNameCannotBeNullException()));
            var containsInViewList = (_skillsView ?? throw new CannotLoadSkillsException())
                .Any(sv => sv.name.Equals(s.name));
            return isGrandChildren && containsInViewList;
        });
    }

    private static void Draw(IReadOnlyList<SkillView> skillsView)
    {
        for (var i = 0; i < skillsView.Count; i++)
        {
            var skillView = skillsView[i];
            var skillKnowledge = (_skillsKnowledge ?? throw new CannotLoadSkillsException())
                .FirstOrDefault(sk => sk.skill.Equals(skillView.name));

            var knowledge = "desconhecido";
            if (skillKnowledge != null)
            { 
                knowledge = skillKnowledge.knowledge;
            }

            var spriteName = $"{skillView.image}-{knowledge}";
            var gameObjectTag = $"Skill_{i + 1}";
            
            DrawSpriteToGameObject(spriteName, gameObjectTag);
        }
    }

    public void OnClickNext()
    {
        if (CurrentHeroIndex + 1 == Heroes.Length)
        {
            SceneManager.LoadScene("Camp");
        }
        else
        {
            CurrentHeroIndex++;
        }
    }
    
    public void OnClickClose()
    {
        SceneManager.LoadScene("Camp");
    }

    public void OnClickSkill(int index)
    {
        if (IsVisible)
        {
            return;
        }
        
        SelectedSkillIndex = index;
        
        OpenOptions();
    }

    private void OpenOptions()
    {
        Toggle();
        
        WriteSkillDescription();
    }

    public void CloseOptions()
    {
        Toggle();
    }

    public void OnClickSelectOption(string option)
    {
        Toggle();

        var heroName = Heroes[CurrentHeroIndex];
        var hero = HeroService.LoadHero(heroName);

        var skillName = ArrangedSkillKnowledges[SelectedSkillIndex].name;

        try
        {
            SkillService.AddSkill(hero, skillName, option);
        }
        catch (BusinessException.BusinessException e)
        {
            AddSkillError.transform.localScale = new Vector3(1, 1, 1);
            ErrorMessage = GameObject.FindGameObjectWithTag("ErrorMessage").GetComponent<Text>();
            ErrorMessage.text = e.Message;
        }
    }

    private void Toggle()
    {
        Vector3? scale;
        
        if (IsVisible)
        {
            scale = new Vector3(0, 0, 0);
            IsVisible = false;
        }
        else
        {
            scale = new Vector3(1, 1, 1);
            IsVisible = true;
        }

        SelectKnowledge.transform.localScale = (Vector3) scale;
    }

    private void WriteSkillDescription()
    {
        var skills = Arrange(Heroes[CurrentHeroIndex]);
        var skillView = skills[SelectedSkillIndex];
        var skill = (_skills ?? throw new CannotLoadSkillsException()).First(s => s.name.Equals(skillView.name));
        
        SkillTitle.text = skill.name;
        SkillDescription.text = skill.description;
    }

    private static void DrawSpriteToGameObject(string spriteName, string gameObjectTag)
    {
        GameObject.FindGameObjectWithTag(gameObjectTag).GetComponent<Image>().sprite = LoadSpriteByName(spriteName);
    }

    private static Sprite LoadSpriteByName(string name)
    {
        return Resources.Load<Sprite>($"Sprites/SkillsViewer/{name}");
    }

    public void OnClickCloseError()
    {
        AddSkillError.transform.localScale = new Vector3(0, 0, 0);
    }
}