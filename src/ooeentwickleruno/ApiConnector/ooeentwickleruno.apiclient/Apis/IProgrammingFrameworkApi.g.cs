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

public partial interface IProgrammingFrameworkApi : IBaseApi
{
    [Post("/ProgrammingFramework/Add")]
    Task<global::ProgrammingFrameworkDto> Add(global::ProgrammingFrameworkDto programmingFrameworkDto);

    [Post("/ProgrammingFramework/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::ProgrammingFrameworkDto> programmingFrameworkDtoList);

    [Delete("/ProgrammingFramework/Delete")]
    Task Delete(Guid id);

    [Get("/ProgrammingFramework/Get")]
    Task<global::ProgrammingFrameworkDto> Get(Guid id);

    [Get("/ProgrammingFramework/GetAll")]
    Task<List<global::ProgrammingFrameworkDto>> GetAll();

    [Get("/ProgrammingFramework/GetAllFull")]
    Task<List<ProgrammingFrameworkFull>> GetAllFull();

    [Get("/ProgrammingFramework/GetFull")]
    Task<ProgrammingFrameworkFull> GetFull(Guid id);

    [Get("/ProgrammingFramework/GetLast")]
    Task<global::ProgrammingFrameworkDto?> GetLast();

    [Post("/ProgrammingFramework/Save")]
    Task<global::ProgrammingFrameworkDto> Save(global::ProgrammingFrameworkDto programmingFrameworkDto);
}
