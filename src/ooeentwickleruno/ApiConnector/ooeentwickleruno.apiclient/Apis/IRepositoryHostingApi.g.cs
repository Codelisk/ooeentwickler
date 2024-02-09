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

public partial interface IRepositoryHostingApi : IBaseApi
{
    [Post("/RepositoryHosting/Add")]
    Task<global::RepositoryHostingDto> Add(global::RepositoryHostingDto repositoryHostingDto);

    [Post("/RepositoryHosting/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::RepositoryHostingDto> repositoryHostingDtoList);

    [Delete("/RepositoryHosting/Delete")]
    Task Delete(Guid id);

    [Get("/RepositoryHosting/Get")]
    Task<global::RepositoryHostingDto> Get(Guid id);

    [Get("/RepositoryHosting/GetAll")]
    Task<List<global::RepositoryHostingDto>> GetAll();

    [Get("/RepositoryHosting/GetAllFull")]
    Task<List<RepositoryHostingFull>> GetAllFull();

    [Get("/RepositoryHosting/GetFull")]
    Task<RepositoryHostingFull> GetFull(Guid id);

    [Get("/RepositoryHosting/GetLast")]
    Task<global::RepositoryHostingDto?> GetLast();

    [Post("/RepositoryHosting/Save")]
    Task<global::RepositoryHostingDto> Save(global::RepositoryHostingDto repositoryHostingDto);
}
