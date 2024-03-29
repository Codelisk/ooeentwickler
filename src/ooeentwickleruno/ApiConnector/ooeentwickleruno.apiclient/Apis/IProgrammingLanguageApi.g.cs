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

public partial interface IProgrammingLanguageApi : IBaseApi
{
    [Post("/ProgrammingLanguage/Add")]
    Task<global::ProgrammingLanguageDto> Add(global::ProgrammingLanguageDto programmingLanguageDto);

    [Post("/ProgrammingLanguage/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::ProgrammingLanguageDto> programmingLanguageDtoList);

    [Delete("/ProgrammingLanguage/Delete")]
    Task Delete(Guid id);

    [Get("/ProgrammingLanguage/Get")]
    Task<global::ProgrammingLanguageDto> Get(Guid id);

    [Get("/ProgrammingLanguage/GetAll")]
    Task<List<global::ProgrammingLanguageDto>> GetAll();

    [Get("/ProgrammingLanguage/GetAllFull")]
    Task<List<ProgrammingLanguageFull>> GetAllFull();

    [Get("/ProgrammingLanguage/GetFull")]
    Task<ProgrammingLanguageFull> GetFull(Guid id);

    [Get("/ProgrammingLanguage/GetLast")]
    Task<global::ProgrammingLanguageDto?> GetLast();

    [Post("/ProgrammingLanguage/Save")]
    Task<global::ProgrammingLanguageDto> Save(global::ProgrammingLanguageDto programmingLanguageDto);
}
