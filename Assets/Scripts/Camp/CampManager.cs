using System;
using SkillsViewer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Camp
{
    public class CampManager : MonoBehaviour
    {
        private string SelectedHeroName;
        private GameObject Team;
        private GameObject Popup;
        private GameObject Confirm;

        private CampService CampService;

        private void Awake()
        {
            Team = GameObject.FindGameObjectWithTag("Team");
            Popup = GameObject.FindGameObjectWithTag("Popup");
            Confirm = GameObject.FindGameObjectWithTag("Confirm");
            CampService = CampService.GetInstance();
        }

        public void OnClickVillage()
        {
            SceneManager.LoadScene("Village");
        }

        public void OnClickForest()
        {
            Confirm.transform.localScale = new Vector3(1, 1, 1);
        }

        public void OnClickConfirm()
        {
            CampService.CreateNewBattle();
            
            SceneManager.LoadScene("TurnBattle");
        }

        public void OnClickCancel()
        {
            Confirm.transform.localScale = new Vector3(0, 0, 0);
        }
        
        public void OnClickTeam()
        {
            Team.transform.localScale = new Vector3(1, 1, 1);
        }

        public void OnClickClosePopup()
        {
            Popup.transform.localScale = new Vector3(0, 0, 0);
        }

        public void OnClickCloseTeam()
        {
            Team.transform.localScale = new Vector3(0, 0, 0);
        }

        public void OnClickHero(string heroName)
        {
            SelectedHeroName = heroName;
            Popup.transform.localScale = new Vector3(1, 1, 1);
        }

        public void OnClickSkill()
        {
            SkillsViewerService.GetInstance().Heroes = new[] {SelectedHeroName};
            SceneManager.LoadScene("SkillsViewer");
        }

        public void OnClickEquipment()
        {
            throw new NotImplementedException();
        }
    }
}