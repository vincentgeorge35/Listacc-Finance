using AutoMapper;
using ListaccFinance.API.Data.Model;
using ListaccFinance.API.Data.ViewModel;
using ListaccFinance.API.SendModel;
using Microsoft.AspNetCore.Identity;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Mapping for downloads
        CreateMap<Department, DepartMentViewModel>();
        CreateMap<IdentityUser<int>, IdentityU>();

        CreateMap<User, UserViewModel>().IncludeBase<IdentityUser<int>, IdentityU>();
        CreateMap<Person, PersonViewModel>();
        CreateMap<CostCategory, CostCategoryViewModel>();
        CreateMap<Project, ProjectViewModel>();
        CreateMap<Client, ClientViewModel>();
        CreateMap<Service, ServiceViewModel>();


        // Mapping for uploads
        CreateMap<DepartmentUpViewModel, Department>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PersonUpViewModel, Person>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<CostCategoryUpViewModel, CostCategory>().ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<ProjectUpViewModel, Project>().ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(x => x.DepartmentOnlineEntryId))
                                                .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<ClientUpViewModel, Client>().ForMember(dest => dest.PersonId , opt => opt.MapFrom(x => x.PersonOnlineEntryId))
                                              .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<ExpenditureUpViewModel, Expenditure>().ForMember(dest => dest.ClientId, opt => opt.MapFrom(x => x.ClientOnlineEntryId))
                                              .ForMember(dest => dest.CostCategoryId, opt => opt.MapFrom(x => x.CostCategoryOnlineEntryId))
                                              .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(x => x.ProjectOnlineEntryId))
                                              .ForMember(dest => dest.IssuerId, opt => opt.MapFrom(x => x.IssuerOnlineEntryId))
                                              .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<ServiceUpViewModel, Service>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(x => x.ProjectOnlineEntryId))
                                                .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<IncomeUpViewModel, Income>().ForMember(dest => dest.ClientId, opt => opt.MapFrom(x => x.ClientOnlineEntryId))
                                              .ForMember(dest => dest.IncomeId, opt => opt.MapFrom(x => x.IncomeOnlineEntryId))
                                              .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(x => x.ServiceOnlineEntryId))
                                              .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.UserOnlineEntryId))
                                              .ForMember(dest => dest.Id, opt => opt.Ignore());

    // Mapper for CurrentUser login
        CreateMap<User, CurrentUser>();

    //Mapper for returning list of users
        CreateMap<User, SearchProps>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.Person.firstName))
                                      .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.Person.LastName))
                                      .ForMember(dest => dest.Gender, opt => opt.MapFrom(x => x.Person.Gender));

    // Mapper for Returning User
        CreateMap<User, RegisterModel>().ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(s => s.Person.DateOfBirth))
                                        .ForMember(dest => dest.firstName, opt => opt.MapFrom(s => s.Person.firstName))
                                        .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.Person.LastName))
                                        .ForMember(dest => dest.Gender, opt => opt.MapFrom(s => s.Person.Gender));
    }
}