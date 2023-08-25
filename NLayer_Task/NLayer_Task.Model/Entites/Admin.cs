using Infrastructure.Model;

namespace NLayer_Task.Model.Entites
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }
        public string? AdminFullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; } = true;

    }
}
