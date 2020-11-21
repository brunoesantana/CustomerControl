using CustomerControl.CrossCutting.Dto.Base;

namespace CustomerControl.CrossCutting.Dto.User
{
    public class UserUpdateDTO : BaseUpdateDTO
    {
        public string UserName { get; set; }
    }
}