using AspireDemo.Domain.Heroes;
using AspireDemo.Domain.Teams;
using Vogen;

namespace AspireDemo.Infrastructure.Persistence.Configuration;

[EfCoreConverter<TeamId>]
[EfCoreConverter<HeroId>]
[EfCoreConverter<MissionId>]
internal sealed partial class VogenEfCoreConverters;