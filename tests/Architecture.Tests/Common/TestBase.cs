using AspireDemo.Application.Common.Interfaces;
using AspireDemo.Domain.Common.Base;
using AspireDemo.Infrastructure.Persistence;
using AspireDemo.WebApi;
using System.Reflection;

namespace AspireDemo.Architecture.UnitTests.Common;

public abstract class TestBase
{
    protected static readonly Assembly DomainAssembly = typeof(AggregateRoot<>).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IApplicationDbContext).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(IWebApiMarker).Assembly;
}