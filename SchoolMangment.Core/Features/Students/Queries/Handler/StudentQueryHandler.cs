using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Students.Queries.Models;
using SchoolMangment.Core.Features.Students.Queries.Responses;
using SchoolMangment.Core.Resurces;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Core.Wrappers;
using SchoolMangment.Data.Entities;
using SchoolMangment.Services.Abstracts;
using System.Linq.Expressions;

namespace SchoolMangment.Core.Features.Students.Queries.Handler
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentQuery, Response<IEnumerable<GetStudentResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fieldes
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructers
        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
            : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handler Funcation
        public async Task<Response<IEnumerable<GetStudentResponse>>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllAsync();
            var studentMapped = _mapper.Map<IEnumerable<GetStudentResponse>>(students);

            var result = Success(studentMapped);

            result.Meta = new { Count = studentMapped.Count() };

            return result;
        }
        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdWithIncludeAsync(request.Id);

            if (student == null)
                return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = _mapper.Map<GetSingleStudentResponse>(student);

            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression
               = e => new GetStudentPaginatedListResponse(e.Id, e.NameEn, e.Address, e.Department.DepartmentNameEn);

            var querable = _studentService.GetAllQueryable();

            var filterQuery = _studentService.FiltterPaginatedQueryable(request.OrderBy, request.Search);

            var paginatedList = await filterQuery.Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count };

            return paginatedList;
        }
        #endregion
    }
}
