using AutoMapper;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extensions;

public static class BusinessServiceExtensions
{
	public static IServiceCollection AddBusinessServices(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();

		RegisterServices(services, assembly);
		RegisterAutoMapper(services, assembly);

		return services;
	}

	private static void RegisterServices(IServiceCollection services, Assembly assembly)
	{
		var serviceTypes = assembly.GetTypes()
			.Where(t => t.IsClass && !t.IsAbstract)
			.Select(t => new
			{
				Implementation = t,
				Interface = t.GetInterfaces().FirstOrDefault(i =>
					i.IsGenericType &&
					i.GetGenericTypeDefinition() == typeof(IService<,,>))
			})
			.Where(t => t.Interface is not null);

		foreach (var type in serviceTypes)
		{
			var specificInterface = type.Implementation.GetInterfaces()
				.FirstOrDefault(i => i != type.Interface && type.Interface!.IsAssignableFrom(i));

			var interfaceToRegister = specificInterface ?? type.Interface!;
			services.AddScoped(interfaceToRegister, type.Implementation);
		}
	}

	private static void RegisterAutoMapper(IServiceCollection services, Assembly assembly)
	{
		services.AddAutoMapper(cfg => cfg.AddMaps(assembly));
	}
}
