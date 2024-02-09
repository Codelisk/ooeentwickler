﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Framework.ApiClient.Apis.Base;
using Refit;

namespace ooeentwickleruno.apiclient;

public partial interface IAccountCompensationApi : IBaseApi
{
    [Post("/AccountCompensation/Add")]
    Task<global::AccountCompensationDto> Add(global::AccountCompensationDto accountCompensationDto);

    [Post("/AccountCompensation/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::AccountCompensationDto> accountCompensationDtoList);

    [Delete("/AccountCompensation/Delete")]
    Task Delete(Guid accountId);

    [Get("/AccountCompensation/Get")]
    Task<global::AccountCompensationDto> Get(Guid accountId);

    [Get("/AccountCompensation/GetAll")]
    Task<List<global::AccountCompensationDto>> GetAll();

    [Get("/AccountCompensation/GetAllFull")]
    Task<List<AccountCompensationFull>> GetAllFull();

    [Get("/AccountCompensation/GetFull")]
    Task<AccountCompensationFull> GetFull(Guid accountId);

    [Get("/AccountCompensation/GetLast")]
    Task<global::AccountCompensationDto?> GetLast();

    [Post("/AccountCompensation/Save")]
    Task<global::AccountCompensationDto> Save(global::AccountCompensationDto accountCompensationDto);
}
