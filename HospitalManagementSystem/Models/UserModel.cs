namespace HospitalManagementSystem.UI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int TcIdNo { get; set; }
        public int RoleId { get; set; }
    }
}
