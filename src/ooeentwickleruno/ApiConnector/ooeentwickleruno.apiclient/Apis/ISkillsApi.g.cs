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

public partial interface ISkillsApi : IBaseApi
{
    [Post("/Skills/Add")]
    Task<global::SkillsDto> Add(global::SkillsDto skillsDto);

    [Post("/Skills/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::SkillsDto> skillsDtoList);

    [Delete("/Skills/Delete")]
    Task Delete(Guid accountId);

    [Get("/Skills/Get")]
    Task<global::SkillsDto> Get(Guid accountId);

    [Get("/Skills/GetAll")]
    Task<List<global::SkillsDto>> GetAll();

    [Get("/Skills/GetAllFull")]
    Task<List<SkillsFull>> GetAllFull();

    [Get("/Skills/GetFull")]
    Task<SkillsFull> GetFull(Guid accountId);

    [Get("/Skills/GetLast")]
    Task<global::SkillsDto> GetLast();

    [Post("/Skills/Save")]
    Task<global::SkillsDto> Save(global::SkillsDto skillsDto);
}