using System.ComponentModel.DataAnnotations.Schema;

namespace KeeneticClientSwitch.Data.Models;

public class LastLogin
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public DateTimeOffset RecordedAt { get; set; }
}
