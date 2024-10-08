﻿using Cafe.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Api.Utils
{
    public static class ResponseResult {

        public static IActionResult ToResult<T>(this BaseResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

