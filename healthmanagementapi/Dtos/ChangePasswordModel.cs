﻿namespace healthmanagementapi.Dtos
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }

}
