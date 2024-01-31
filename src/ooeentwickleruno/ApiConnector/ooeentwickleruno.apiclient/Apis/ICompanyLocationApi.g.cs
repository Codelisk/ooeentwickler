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

public partial interface ICompanyLocationApi : IBaseApi
{
    [Post("/CompanyLocation/Add")]
    Task<global::CompanyLocationDto> Add(global::CompanyLocationDto companyLocationDto);

    [Post("/CompanyLocation/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::CompanyLocationDto> companyLocationDtoList);

    [Delete("/CompanyLocation/Delete")]
    Task Delete(Guid companyId);

    [Get("/CompanyLocation/Get")]
    Task<global::CompanyLocationDto> Get(Guid companyId);

    [Get("/CompanyLocation/GetAll")]
    Task<List<global::CompanyLocationDto>> GetAll();

    [Get("/CompanyLocation/GetAllFull")]
    Task<List<CompanyLocationFull>> GetAllFull();

    [Get("/CompanyLocation/GetFull")]
    Task<CompanyLocationFull> GetFull(Guid companyId);

    [Get("/CompanyLocation/GetLast")]
    Task<global::CompanyLocationDto> GetLast();

    [Post("/CompanyLocation/Save")]
    Task<global::CompanyLocationDto> Save(global::CompanyLocationDto companyLocationDto);
}
