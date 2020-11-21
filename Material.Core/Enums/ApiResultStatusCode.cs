using System.ComponentModel.DataAnnotations;

namespace Material.Core.Enums
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Success")]
        Success = 0,

        [Display(Name = "ServerError")]
        ServerError = 1,

        [Display(Name = "BadRequest")]
        BadRequest = 2,

        [Display(Name = "NotFound")]
        NotFound = 3,

        [Display(Name = "ListEmpty")]
        ListEmpty = 4,

        [Display(Name = "LogicError")]
        LogicError = 5,

        [Display(Name = "UnAuthorized")]
        UnAuthorized = 6
    }
}
