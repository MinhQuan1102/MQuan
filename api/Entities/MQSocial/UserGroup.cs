namespace api.Entities.MQSocial
{
    public class UserGroup
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Group? Group { get; set; }
        public int? Role { get; set; }
        public bool? ReceiveNoti { get; set; } = true;
    }
}
