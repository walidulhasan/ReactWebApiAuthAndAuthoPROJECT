﻿namespace Backend_WebApi.Core.Dtos.Auth;

public class LoginServiceResponseDto
{
    public string NewToken { get; set; }
    //This would be returned to front-end
    public UserInfoResult UserInfo { get; set; }
}
