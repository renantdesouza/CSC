using System.Collections.Generic;

public class DecisionViewService
{
    private static DecisionViewService _instance;
    private readonly Dictionary<int, string> DecisionsName;
    private readonly Dictionary<int, List<OptionButton>> OptionsButtons;

    private DecisionViewService()
    {
        DecisionsName = new Dictionary<int, string>()
        {
            {1, "Decision_1"},
            {2, "Decision_2"},
            {3, "Decision_3"}
        };

        OptionsButtons = new Dictionary<int, List<OptionButton>>()
        {
            {
                1, new List<OptionButton>()
                {
                    new OptionButton()
                    {
                        TextTag = "FirstText",
                        ButtonTag = "FirstButton"
                    }
                }
            },
            {
                2, new List<OptionButton>()
                {
                    new OptionButton()
                    {
                        TextTag = "FirstText",
                        ButtonTag = "FirstButton"
                    },
                    new OptionButton()
                    {
                        TextTag = "SecondText",
                        ButtonTag = "SecondButton"
                    }
                }
            },
            {
                3, new List<OptionButton>()
                {
                    new OptionButton()
                    {
                        TextTag = "FirstText",
                        ButtonTag = "FirstButton"
                    },
                    new OptionButton()
                    {
                        TextTag = "SecondText",
                        ButtonTag = "SecondButton"
                    },
                    new OptionButton()
                    {
                        TextTag = "ThirdText",
                        ButtonTag = "ThirdButton"
                    }
                }
            }
        };
    }

    public static DecisionViewService GetInstance() => _instance ?? (_instance = new DecisionViewService());

    public string GetDecisionName(int count)
    {
        return DecisionsName[count];
    }

    public List<OptionButton> GetButtonsName(int count)
    {
        return OptionsButtons[count];
    }
    
    public class OptionButton
    {
        public string TextTag;
        public string ButtonTag;
    }
}