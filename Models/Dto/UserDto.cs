﻿namespace Seat_broker_backend.Models.Dto
{
    public class UserDto
    {  
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? UserType { get; set; }
    }
}
