namespace Assignment1.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public IFormFile? Photo { get; set; }
        public string Description { get; set; }
        public string Mission { get; set; }
        public string Vision { get; set; }
        public string Goal { get; set; }
        public string Values { get; set; }
        public string? ExistingPhotoPath { get; set; }
        public bool IsMissionSelected { get; set; }
        public bool IsVisionSelected { get; set; }
        public bool IsGoalSelected { get; set; }
        public bool IsValuesSelected { get; set; }

    }
}
