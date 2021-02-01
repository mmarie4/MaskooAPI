using System;

namespace MaskooAPI.Models.Users
{
    public class UserResponse : EntityResponse
    {
        public Guid Id { get; set; }

        public string Token { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
