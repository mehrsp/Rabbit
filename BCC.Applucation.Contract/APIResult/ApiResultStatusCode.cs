using System.ComponentModel.DataAnnotations;

namespace BCC.Application.Contract.APIResult;

public enum ApiResultStatusCode : int
{
    /// <summary>
    /// عملیات با موفقیت انجام شد.
    /// </summary>
    [Display(Name = "عملیات با موفقیت انجام شد.")]
    Success = 200,
    /// <summary>
    /// خطایی در سرور رخ داده است
    /// </summary>
    [Display(Name = "خطایی در سرور رخ داده است")]
    ServerError = 500,
    /// <summary>
    /// پارامتر های ارسالی معتبر نیستند
    /// </summary>
    [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
    BadRequest = 400,
    /// <summary>
    /// یافت نشد
    /// </summary>
    [Display(Name = "موردی یافت نشد")]
    NotFound = 404,
    /// <summary>
    /// یافت شد
    /// </summary>
    [Display(Name = "یافت شد")]
    Found = 410,
    /// <summary>
    /// لیست خالی است
    /// </summary>
    [Display(Name = "لیست خالی است")]
    ListEmpty = 204,
    /// <summary>
    /// خطایی در پردازش رخ داد
    /// </summary>
    [Display(Name = "خطایی در پردازش رخ داد")]
    LogicError = 409,
    /// <summary>
    /// خطای احراز هویت
    /// </summary>
    [Display(Name = "خطای احراز هویت")]
    UnAuthorized = 403,




    /// ادامه ی فرآیند به دلایل بیزینسی امکان پذیر نیست
    /// </summary>
    [Display(Name = "ادامه ی فرآیند به دلایل بیزینسی امکان پذیر نیست")]
    ProcessCanceled = 1002,


    [Display(Name = "هیچ تغییری در بانک اطلاعاتی ایجاد نشد")]
    NoAffectedRow = 412

}