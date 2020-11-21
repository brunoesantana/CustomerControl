using System;

namespace CustomerControl.CrossCutting.Dto.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}