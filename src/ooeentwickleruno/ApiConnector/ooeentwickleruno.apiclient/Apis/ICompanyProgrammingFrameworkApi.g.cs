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

public partial interface ICompanyProgrammingFrameworkApi : IBaseApi
{
    [Post("/CompanyProgrammingFramework/Add")]
    Task<global::CompanyProgrammingFrameworkDto> Add(global::CompanyProgrammingFrameworkDto companyProgrammingFrameworkDto);

    [Post("/CompanyProgrammingFramework/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::CompanyProgrammingFrameworkDto> companyProgrammingFrameworkDtoList);

    [Delete("/CompanyProgrammingFramework/Delete")]
    Task Delete(Guid id);

    [Get("/CompanyProgrammingFramework/Get")]
    Task<global::CompanyProgrammingFrameworkDto> Get(Guid id);

    [Get("/CompanyProgrammingFramework/GetAll")]
    Task<List<global::CompanyProgrammingFrameworkDto>> GetAll();

    [Get("/CompanyProgrammingFramework/GetAllFull")]
    Task<List<CompanyProgrammingFrameworkFull>> GetAllFull();

    [Get("/CompanyProgrammingFramework/GetFull")]
    Task<CompanyProgrammingFrameworkFull> GetFull(Guid id);

    [Get("/CompanyProgrammingFramework/GetLast")]
    Task<global::CompanyProgrammingFrameworkDto?> GetLast();

    [Post("/CompanyProgrammingFramework/Save")]
    Task<global::CompanyProgrammingFrameworkDto> Save(global::CompanyProgrammingFrameworkDto companyProgrammingFrameworkDto);
}
