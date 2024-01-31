using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ApiClient.Apis.Base;
using Refit;

public partial interface ITestApi : IBaseApi
{
    [Post("/Test/Add")]
    Task<global::TestDto> Add(global::TestDto testDto);

    [Post("/Test/AddRange")]
    Task AddRange(System.Collections.Generic.List<global::TestDto> testDtoList);

    [Delete("/Test/Delete")]
    Task Delete(Guid id);

    [Get("/Test/Get")]
    Task<global::TestDto> Get(Guid id);

    [Get("/Test/GetAll")]
    Task<List<global::TestDto>> GetAll();

    [Get("/Test/GetAllFull")]
    Task<List<TestFull>> GetAllFull();

    [Get("/Test/GetFull")]
    Task<TestFull> GetFull(Guid id);

    [Get("/Test/GetLast")]
    Task<global::TestDto> GetLast();

    [Post("/Test/Save")]
    Task<global::TestDto> Save(global::TestDto testDto);
}
