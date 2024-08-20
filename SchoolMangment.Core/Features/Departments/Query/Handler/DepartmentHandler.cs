using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Departments.Query.Modles;
using SchoolMangment.Core.Features.Departments.Query.Responses;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Core.Wrappers;
using SchoolMangment.Data.Entities;
using SchoolMangment.Services.Abstracts;
using System.Linq.Expressions;

namespace SchoolMangment.Core.Features.Departments.Query.Handler
{
    public class DepartmentHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fildes
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DepartmentHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService, IMapper mapper, IStudentService studentService)
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handler Funcations
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Service Get by Id includes St Sub Inst
            var response = await _departmentService.GetDepartmentById(request.Id);
            // check null
            if (response == null)
                return NotFound<GetDepartmentByIdResponse>("not found");
            // Maping
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(response);

            // pag
            Expression<Func<Student, StudentResponse>> expression
             = e => new StudentResponse(e.Id, e.NameEn);

            var studentQueryable = _studentService.GetStudentByDepartmentIdQueryable(request.Id);

            var paginatedList = await studentQueryable.Select(expression)
                    .ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);

            //paginatedList.Meta = new { Count = paginatedList.Data.Count };

            mapper.StudentList = paginatedList;

            // return Response
            return Success(mapper);
        }
        #endregion
    }
}
