namespace Skillustrator.ViewModels.Write 
{
    public class PersonSkillViewModel
    {      
        public int PersonId { get; set; }
        
        public int SkillId { get; set; }
        
        public string SkillLevelCode { get; set; }

        public string TimeUsedCode { get; set; }

        public string TimeLastUsedCode { get; set; }
    }
}