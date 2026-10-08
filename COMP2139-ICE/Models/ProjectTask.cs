using System.ComponentModel.DataAnnotations;

namespace COMP2139_ICE.Models
{
    public class ProjectTask
    {
        // Primary Key
        public int ProjectTaskId { get; set; }

        // Task Başlığı (Zorunlu alan)
        [Required]
        public string Title { get; set; } = string.Empty;

        // Task Açıklaması
        public string? Description { get; set; }

        // Foreign Key (Hangi projeye ait olduğunu belirtir)
        public int ProjectId { get; set; }

        // Navigation Property (İlişki için)
        public Project? Project { get; set; }
    }
}